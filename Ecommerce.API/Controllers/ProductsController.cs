

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
            var Products = await _work.Products.GetAllAsync(x=>x.Category, x=>x.Photos);
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
            var Product = await _work.Products.GetByIdAsync(id);
            if (Product == null)
            {
                return NotFound(new ResponseClass((int)HttpStatusCode.NotFound, $"Product with ID {id} not found."));

            }
            return Ok(Product);
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct(ProductDTO dto)
        {
            if (dto == null)
            {
                return NotFound(new ResponseClass((int)HttpStatusCode.BadRequest, "Product data is null."));

            }
            var product = mapper.Map<Product>(dto);
            await _work.Products.AddAsync(product);
            await _work.SaveChangesAsync(); 
            return Ok(new ResponseClass((int)HttpStatusCode.Created, $"Product with ID {product.Id} is created."));
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO Product)
        {
            if (Product == null || Product.Id < 1)
            {
                return NotFound(new ResponseClass((int)HttpStatusCode.BadRequest, "Product data is invalid."));
            }
            var existingProduct = await _work.Products.GetByIdAsync(Product.Id);
            if (existingProduct == null)
            {
                return NotFound(new ResponseClass((int)HttpStatusCode.NotFound, $"Product with ID {Product.Id} not found."));
            }
            var dto = mapper.Map<Product>(Product);

            await _work.Products.UpdateAsync(dto);
            await _work.SaveChangesAsync();
            return Ok(new ResponseClass((int)HttpStatusCode.NoContent, $"Product with ID {Product.Id} was updated."));
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var Product = await _work.Products.GetByIdAsync(id);
            if (Product == null)
            {
                return NotFound(new ResponseClass((int)HttpStatusCode.NotFound, $"Product with ID {id} not found."));
            }
            var dto = mapper.Map<Product>(Product);
            dto.IsDeleted = true;
            dto.DeletedAt = DateTime.Now;
            await _work.Products.UpdateAsync(dto);
            await _work.SaveChangesAsync();
            return Ok(new ResponseClass((int)HttpStatusCode.NoContent, $"Product with ID {Product.Id} was deleted."));
        }
    }
}
