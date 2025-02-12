
using Microsoft.AspNetCore.Mvc;
using ShopClothing.Application.DTOs.Product;
using ShopClothing.Application.Services.Interfaces.Product;

namespace ShopClothing.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {

        [HttpPost("add")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddProduct([FromForm] CreateProduct product)
        {
          if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
          var result = await productService.AddAsync(product);
            return result.Success ? Ok(result) : BadRequest(result);

        }
    }
}
