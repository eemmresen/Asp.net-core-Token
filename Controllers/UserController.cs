using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Domain;
using WebApplication2.Domain.Responses;
using WebApplication2.Domain.Services;
using WebApplication2.Resources;
using WebApplication2.services;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //injekşın kısmı
        private readonly IUserService userService;
        private readonly IMapper mapper;

        //-------------------------------------

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }
        //------------------------------------------------------------
        
        [Authorize]//herkese açık değil ve token ile işlem yapılacak
        [HttpGet]
        public IActionResult GetUser() 
        {
            IEnumerable<Claim> claims = User.Claims;

            string userId = claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value;



            BaseResponse<User> userResponse = userService.FindById(int.Parse( userId));

            if (userResponse.Success)
            {
                return Ok(userResponse.Extra);
            }
            else
            {
                return BadRequest(userResponse.ErrorMessage);
            }
            





        }




        [AllowAnonymous]//herkese açık olduğunu gösteriyor ve bir tokın beklemediğini belitriyor
        [HttpPost]
        public IActionResult AddUser(UserResource userResource) 
        {
            User user = mapper.Map<UserResource, User>(userResource);
           
            BaseResponse<User> userResponse= userService.adduser(user);


            if (userResponse.Success)
            {
                return Ok(userResponse.Extra);
            }
            else
            {
                return BadRequest(userResponse.ErrorMessage);
            }



        }




    }
}