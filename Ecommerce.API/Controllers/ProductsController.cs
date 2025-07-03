

using AutoMapper;
using Ecommerce.API.Helper;
using Ecommerce.Core.DTO.Products;
using Ecommerce.Core.Entities.Product;
using Ecommerce.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        public ProductsController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllProducts()
        {
            var Products = await _work.ProductRepositiry.GetAllAsync(x=>x.Category, x=>x.Photos);
            if (Products == null || !Products.Any())
            {
                return NotFound(new ResponseClass((int)HttpStatusCode.NotFound));
            }
            var res= mapper.Map<List<ProductDTO>>(Products);
            return Ok(new ResponseClass((int)HttpStatusCode.Found, data: res));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = await _work.ProductRepositiry.GetByIdAsync(id, x => x.Category, x => x.Photos);
                var result = mapper.Map<ProductDTO>(product);
                if (product != null)
                {
                    return Ok(result);
                }
                return BadRequest(new ResponseClass(400, "This Product Not Found"));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct(AddProductDTO productDTO)
        {
            try
            {
                await _work.ProductRepositiry.AddAsync(productDTO);

            }
            catch (Exception ex)
            {
                // This will show the real database error
                var errorMessage = ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;
                return BadRequest(errorMessage);
            }
            return Ok(new ResponseClass(200, "Product Added Successfully"));

        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO Product)
        {
            if (Product == null || Product.Id < 1)
            {
                return NotFound(new ResponseClass((int)HttpStatusCode.BadRequest, "Product data is invalid."));
            }
            var existingProduct = await _work.ProductRepositiry.GetByIdAsync(Product.Id);
            if (existingProduct == null)
            {
                return NotFound(new ResponseClass((int)HttpStatusCode.NotFound, $"Product with ID {Product.Id} not found."));
            }
            var dto = mapper.Map<Product>(Product);

            await _work.ProductRepositiry.UpdateAsync(dto);
             return Ok(new ResponseClass((int)HttpStatusCode.NoContent, $"Product with ID {Product.Id} was updated."));
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var Product = await _work.ProductRepositiry.GetByIdAsync(id);
            if (Product == null)
            {
                return NotFound(new ResponseClass((int)HttpStatusCode.NotFound, $"Product with ID {id} not found."));
            }
            var dto = mapper.Map<Product>(Product);
            dto.IsDeleted = true;
            dto.DeletedAt = DateTime.Now;
            await _work.ProductRepositiry.UpdateAsync(dto);
             return Ok(new ResponseClass((int)HttpStatusCode.NoContent, $"Product with ID {Product.Id} was deleted."));
        }
    }
}
