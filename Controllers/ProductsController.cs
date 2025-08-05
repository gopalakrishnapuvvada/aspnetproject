using Microsoft.AspNetCore.Mvc;
using MyApiProject.Models;
using MyApiProject.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _service.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            var createdProduct = await _service.CreateProductAsync(product);

            // Returns 201 Created with the new product's URL
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product product)
        {
            if (product == null || id != product.Id)
                return BadRequest();

            var updatedProduct = await _service.UpdateProductAsync(id, product);
            if (updatedProduct == null)
                return NotFound();

            return Ok(new
            {
                message = "Product updated successfully.",
                data = updatedProduct
            });  // 204 response, successful update without returning content
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _service.DeleteProductAsync(id);
            if (!deleted)
            {
                return NotFound(new { message = $"Product with ID {id} not found." });
            }
            return Ok(new { message = "Product deleted successfully." });
        }
        [HttpDelete("softdelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var result = await _service.SoftDeleteProductAsync(id);
            if (!result)
                return NotFound();

            return Ok(new { message = "Product soft deleted successfully." });
        }
        [HttpGet("activeProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetActiveProducts()
        {
            var products = await _service.GetActiveProductsAsync();
            return Ok(products);
        }
        [HttpGet("activewithoutisdeletedfield")]
        public async Task<ActionResult<IEnumerable<ProductDto>>>  GetNonDeletedProducts()
        {
            var products = await _service.GetAllProductsAsync();

            var activeProducts = products
                .Where(p => !p.IsDeleted)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                })
                .ToList();

            return Ok(activeProducts);
        }
    }
}
