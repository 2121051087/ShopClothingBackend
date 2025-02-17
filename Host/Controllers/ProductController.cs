
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

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var result = await productService.DeleteAsync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("single/{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var result = await productService.GetByIdAsync(id);
            return result != null ? Ok(result) : NotFound(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllProductAsync()
        {
            var result = await productService.GetAllAsync();
            return result != null ? Ok(result) : NotFound(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateProduct product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await productService.UpdateAsync(product);
            return result.Success ? Ok(result) : BadRequest(result);
        }

    }
}
