using Ecommerce.BL.DTOs.ProductDto;
using Ecommerce.BL.Services.Abstractions;
using Ecommerce.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ICollection<Product>> GetAll()
        {
            var result = await  _productService.GetAllAsync();
            return result;

        }
        [HttpGet]
        public async Task<Product> GetById(int id)
        {
          return await  _productService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateDto productCreateDto)
        {
           await _productService.CreateAsync(productCreateDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, ProductUpdateDto productUpdateDto)
        {
            await _productService.UpdateAsync(id, productUpdateDto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
           await  _productService.DeleteAsync(id);
            return Ok();
        }
    }
}
