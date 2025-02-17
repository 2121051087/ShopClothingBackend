using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopClothing.Application.Services.Interfaces.Product.Color;

namespace ShopClothing.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController(IColorService colorService) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await colorService.GetAllAsync();
            return data.Any() ? Ok(data) : NotFound(data);
        }

        [HttpGet("single/{id}")]
        public async Task<IActionResult> GetSingle(Guid id)
        {
            var data = await colorService.GetByIdAsync(id);
            return data != null ? Ok(data) : NotFound();
        }
    }
}
