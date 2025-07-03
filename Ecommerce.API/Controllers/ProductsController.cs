

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
            var Products = await _work.ProductRepository.GetAllAsync(x=>x.Category, x=>x.Photos);
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
                var product = await _work.ProductRepository.GetByIdAsync(id, x => x.Category, x => x.Photos);
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
                await _work.ProductRepository.AddAsync(productDTO);

            }
            catch (Exception ex)
            {
                // This will show the real database error
                var errorMessage = ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;
                return BadRequest(errorMessage);
            }
            return Ok(new ResponseClass(200, "Product Added Successfully"));

        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO productDto)
        {
            try
            {
                await _work.ProductRepository.UpdateAsync(productDto);
                return Ok(new ResponseClass(200, "Product Updated Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseClass(400, ex.Message));
            }
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _work.ProductRepository.GetByIdAsync(id, x => x.Photos, x => x.Category);
                await _work.ProductRepository.DeleteAsync(product);
                return Ok(new ResponseClass(200, "Product Deleted Successfully"));

            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseClass(400, ex.Message));
            }
        }
    }
}
