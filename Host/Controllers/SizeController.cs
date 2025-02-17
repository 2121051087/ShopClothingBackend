using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopClothing.Application.Services.Interfaces.Product.Size;

namespace ShopClothing.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController(ISizeService sizeService) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await sizeService.GetAllAsync();
            return data.Any() ? Ok(data) : NotFound(data);
        }

        [HttpGet("single/{id}")]
        public async Task<IActionResult> GetSingle(Guid id)
        {
            var data = await sizeService.GetByIdAsync(id);
            return data != null ? Ok(data) : NotFound();
        }

    }
}
