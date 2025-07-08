using AutoMapper;
using Ecommerce.API.Helper;
using Ecommerce.Core.DTO.Categories;
using Ecommerce.Core.Entities.Product;
using Ecommerce.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        public CategoriesController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _work.CategoryRepository.GetAllAsync();
            if (categories == null || !categories.Any())
            {
                return NotFound(new ResponseClass ((int)HttpStatusCode.NotFound));
            }
            return Ok(new ResponseClass((int)HttpStatusCode.Found, data: categories));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _work.CategoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                 return NotFound(new ResponseClass((int)HttpStatusCode.NotFound, $"Category with ID {id} not found."));

            }
            return Ok(category);
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory(CategoryDTO dto)
        {
            if (dto == null)
            {
                 return NotFound(new ResponseClass((int)HttpStatusCode.BadRequest,"Category data is null."));

            }
            var category = mapper.Map<Category>(dto);
            await _work.CategoryRepository.AddAsync(category);
              return Ok(new ResponseClass((int)HttpStatusCode.Created, $"Category with ID {category.Id} is created."));
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateDTO category)
        {
            if (category == null || category.Id < 1)
            {
                return NotFound(new ResponseClass((int)HttpStatusCode.BadRequest, "Category data is invalid."));
            }
            var existingCategory = await _work.CategoryRepository.GetByIdAsync(category.Id);
            if (existingCategory == null)
            {
                return NotFound(new ResponseClass((int)HttpStatusCode.NotFound, $"Category with ID {category.Id} not found."));
            }
            var dto = mapper.Map<Category>(category);

            await _work.CategoryRepository.UpdateAsync(dto);
             return Ok(new ResponseClass((int)HttpStatusCode.NoContent, $"Category with ID {category.Id} was updated."));
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _work.CategoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound(new ResponseClass((int)HttpStatusCode.NotFound, $"Category with ID {id} not found."));
            }
            var dto = mapper.Map<Category>(category);
            dto.IsDeleted = true;
            dto.DeletedAt = DateTime.Now;
            await _work.CategoryRepository.UpdateAsync(dto);
             return Ok(new ResponseClass((int)HttpStatusCode.NoContent, $"Category with ID {category.Id} was deleted."));
        }
    }
}
