using Microsoft.Extensions.FileProviders;
using ShopClothing.Application.DependencyInjection;
using ShopClothing.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationService();
builder.Services.AddInfrastructureServices(builder.Configuration);



var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
if (!Directory.Exists(webRootPath))
{
    Directory.CreateDirectory(webRootPath);
}
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(webRootPath),
    RequestPath = "/wwwroot"
});



app.UseInfrastructureService();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
