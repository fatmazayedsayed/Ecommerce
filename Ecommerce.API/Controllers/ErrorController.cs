﻿using Ecommerce.API.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("errors/{statusCode}")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Error(int statusCode)
        {
            return new ObjectResult(new ResponseClass(statusCode));
        }
    }
}
