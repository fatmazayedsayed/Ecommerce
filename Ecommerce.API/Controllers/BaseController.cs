using AutoMapper;
using Ecommerce.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public readonly IUnitOfWork _work;
        protected readonly IMapper mapper;

        public BaseController(IUnitOfWork work,IMapper _mapper )
        {
            _work = work;
            mapper = _mapper;
        }
    }
}
