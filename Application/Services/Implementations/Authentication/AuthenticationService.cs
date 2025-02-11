using AutoMapper;
using FluentValidation;
using ShopClothing.Application.DTOs;
using ShopClothing.Application.DTOs.Identity;
using ShopClothing.Application.Services.Interfaces.Authentication;
using ShopClothing.Application.Services.Interfaces.Logging;
using ShopClothing.Application.Validations;
using ShopClothing.Domain.Entities.Identity;
using ShopClothing.Domain.Interface.Authentication;

namespace ShopClothing.Application.Services.Implementations.Authentication
{
    public class AuthenticationService(ITokenManagement tokenManagement, IUserManagement userManagement,
        IRoleManagement roleManagement, IAppLogger<AuthenticationService> logger,
        IMapper mapper, IValidator<RegisterUser> createUserValidator
        , IValidator<LoginUser> loginUserValidator, IValidationService validationService) : IAuthenticationService
    {
        public async Task<ServiceResponse> Register(RegisterUser user)
        {
            var _validationResult = await validationService.ValidateAsync(user, createUserValidator);
            if (!_validationResult.Success) return _validationResult;

            var mappedModel = mapper.Map<AppUser>(user);
            mappedModel.UserName = user.Email;
            mappedModel.PasswordHash = user.Password;
            mappedModel.FullName = user.FullName;


            var result = await userManagement.RegisterUser(mappedModel);
            if (!result)
                return new ServiceResponse
                {
                    Message = " Email address might be already in use or unknow error occurred"
                };
            var _user = await userManagement.GetUserByEmail(user.Email);
            var users = await userManagement.GetAllUser();
            bool assignedResult = await roleManagement.AddUserToRole(_user!, users!.Count() > 1 ? "User" : "Admin");

            if (!assignedResult)
            {
                // remove user
                int removeUserResult = await userManagement.RemoveUserByEmail(_user!.Email!);
                if (removeUserResult <= 0)
                {
                    // error occurred while rolling back changes 
                    // then log the error 

                    logger.LogError(new Exception($"User with Email as {_user!.Email} failed to be remove as a result of role assignment issue"),
                        "User could not be assigned Role");
                    return new ServiceResponse { Message = "Error occurred in create account" };
                }
            }
            return new ServiceResponse { Success = true, Message = "Account created successfully" };
        }
        public async  Task<LoginResponse> Login(LoginUser user)
        {
            var _validationResult = await validationService.ValidateAsync(user, loginUserValidator);
            if (!_validationResult.Success)
            {
                return new LoginResponse(Message: _validationResult.Message);
            }
            var mappedModel = mapper.Map<AppUser>(user);
            mappedModel.PasswordHash = user.Password;

            bool loginResult = await userManagement.LoginUser(mappedModel);
            if (!loginResult)
            {
                return new LoginResponse(Message: "Email not found or invalid credentials");
            }
            var _user = await userManagement.GetUserByEmail(user.Email);
            var claims = await userManagement.GetUserClaims(_user!.Email!);

            string jwtToken = tokenManagement.GenerateToken(claims);
            string refreshToken = tokenManagement.GetRefreshToken();

            int saveTokenResult = 0;
            bool userTokenCheck = await tokenManagement.ValidateRefreshToken(refreshToken);
            if (userTokenCheck)
                saveTokenResult = await tokenManagement.UpdateRefreshToken(_user!.Id, refreshToken);
            else
                saveTokenResult = await tokenManagement.AddRefreshToken(_user!.Id, refreshToken);


            return saveTokenResult <= 0 ? new LoginResponse(Message: "Internal error occurred while authenticating") :
                new LoginResponse(Success: true,Message:"Login successfully", Token: jwtToken, RefreshToken: refreshToken);
        }


        public async Task<LoginResponse> ReviveToken(string refreshToken)
        {
            bool validateTokenResult = await tokenManagement.ValidateRefreshToken(refreshToken);
            if (!validateTokenResult)
                return new LoginResponse(Message: "Invalid token");

            string userId = await tokenManagement.GetUserIdByRefreshToken(refreshToken);
            AppUser? user = await userManagement.GetUserById(userId);
            var claims = await userManagement.GetUserClaims(user!.Email!);
            string newJwtToken = tokenManagement.GenerateToken(claims);
            string newRefreshToken = tokenManagement.GetRefreshToken();
            await tokenManagement.UpdateRefreshToken(userId, newRefreshToken);
            return new LoginResponse(Success: true, Message: "Updated Token successfully", Token: newJwtToken, RefreshToken: newRefreshToken);
        }
    }
}
