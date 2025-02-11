using FluentValidation;
using ShopClothing.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothing.Application.Validations
{
    public class ValidationService : IValidationService

    {
        public async Task<ServiceResponse> ValidateAsync<T>(T model, IValidator<T> validator)
        {
            var validationResult = await validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {

                var error = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                string errorsToString = string.Join(", ", error);
                return new ServiceResponse { Message = errorsToString };

            }

            return new ServiceResponse { Success = true };
        }
    }
}
