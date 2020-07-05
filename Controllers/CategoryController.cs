using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public IActionResult bir() 
        {
            return Ok("bu metotta kimlik doğrulama yoktur");
        }
        [Authorize]
        public IActionResult iki()
        {
            return Ok("bu metotta kimlik doğrulama vardır");
        }

    }
}