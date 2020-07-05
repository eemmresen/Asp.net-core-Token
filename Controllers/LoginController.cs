using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Domain.Responses;
using WebApplication2.Domain.Services;
using WebApplication2.Extensions;
using WebApplication2.Resources;
using WebApplication2.Security.Token;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
       

        public LoginController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
           
        }


        [HttpPost]
        public IActionResult AccessToken(LoginResource loginResource) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            else
            {


                BaseResponse<AccessToken> accessTokenResponse = authenticationService.CreateAccessToken(loginResource.Email, loginResource.Password);
                if (accessTokenResponse.Success)
                {
                    return Ok(accessTokenResponse.Extra);
                }
                else
                {
                    return BadRequest(accessTokenResponse.ErrorMessage);
                }
            }
        }

        [HttpPost]
        public IActionResult RefreshToken(TokenResource tokenResources) 
        {
            BaseResponse<AccessToken> accessTokenResponse = authenticationService.CreateAccessTokenByRefreshToken(tokenResources.refreshToken);
            if (accessTokenResponse.Success)
            {
                return Ok(accessTokenResponse.Extra);
            }
            return BadRequest(accessTokenResponse.ErrorMessage); 
        }

        [HttpDelete]
        public IActionResult RevokeRefreshRToken(TokenResource tokenResources) 
        {
            BaseResponse<AccessToken> accessTokenResponse = authenticationService.RevokeRefreshRToken(tokenResources.refreshToken);
            if (accessTokenResponse.Success)
            {
                return Ok(accessTokenResponse.Extra);
            }
            else
            {
                return BadRequest(accessTokenResponse.ErrorMessage);
            }
        }


    }
}