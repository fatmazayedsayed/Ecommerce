using AutoMapper;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    public class BugController : BaseController
    {
        public BugController(UnitOfWork _work, IMapper mapper) : base(_work, mapper)
        {
        }
        [HttpGet("Not-Found")]
        public async Task<ActionResult> GetNotFound()
        {
            var category = await _work.CategoryRepository.GetByIdAsync(100);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpGet("Server-Error")]
        public async Task<ActionResult> GetServerError()
        {
            var category = await _work.CategoryRepository.GetByIdAsync(100);
            category.Name = "";
            return Ok(category);
        }

        [HttpGet("Bad-Request/{id}")]
        public async Task<ActionResult> GetBadRequest(int id)
        {

            return Ok();
        }

        [HttpGet("Bad-Request/")]
        public async Task<ActionResult> GetBadRequest()
        {

            return BadRequest();
        }
    }
}
