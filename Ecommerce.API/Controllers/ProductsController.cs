﻿

using AutoMapper;
using Ecommerce.API.Helper;
using Ecommerce.Core.DTO.Products;
using Ecommerce.Core.DTO.Sharing;
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
        public async Task<IActionResult> get([FromQuery] ProductParams productParams)
        {
            try
            {
                var product = await _work.ProductRepository.GetAllAsync(productParams);
                if (product == null || !product.Any())
                {
                    return NotFound(new ResponseClass((int)HttpStatusCode.NotFound));
                }
                var totalCount = await _work.ProductRepository.CountAsync();
                return Ok(new Pagination<ProductDTO>(productParams.PageNumber, productParams.PageSize, totalCount, product));

                //  return BadRequest(new ResponseClass(400, "Products Not Found"));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("Get-By-Id/{id}")]
        public async Task<IActionResult> getById(int id)
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

        [HttpPost("Add-Product")]
        public async Task<IActionResult> add(AddProductDTO productDTO)
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

        [HttpPut("Update-Product")]
        public async Task<IActionResult> update(UpdateProductDTO updateProductDTO)
        {
            try
            {
                await _work.ProductRepository.UpdateAsync(updateProductDTO);
                return Ok(new ResponseClass(200, "Product Updated Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseClass(400, ex.Message));
            }

        }


        [HttpDelete("Delete-product/{Id}")]
        public async Task<IActionResult> delete(int Id)
        {
            try
            {
                var product = await _work.ProductRepository.GetByIdAsync(Id, x => x.Photos, x => x.Category);
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
