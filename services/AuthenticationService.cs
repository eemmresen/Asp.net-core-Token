using Microsoft.CodeAnalysis.FindSymbols;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Domain;
using WebApplication2.Domain.Responses;
using WebApplication2.Domain.Services;
using WebApplication2.Security.Token;

namespace WebApplication2.services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService userService;
        private readonly ITokenHandler tokenHandler;

        public AuthenticationService(IUserService userService, ITokenHandler tokenHandler)
        {
            this.userService = userService;
            this.tokenHandler = tokenHandler;
                
        }
        public BaseResponse<AccessToken> CreateAccessToken(string Email, string Password)
        {

            BaseResponse<User> userResponse= userService.FindByEmailandPassaword(Email, Password);
            if (userResponse.Success)
            {
              AccessToken accessToken=  tokenHandler.CreateAccessToken(userResponse.Extra);
                userService.SaveRefreshToken(userResponse.Extra.Id, accessToken.RefreshToken);
                return new BaseResponse<AccessToken>(accessToken);
            }
            else
            {
                return new BaseResponse<AccessToken>(userResponse.ErrorMessage); 
            }
            
           
            
        }

        public BaseResponse<AccessToken> CreateAccessTokenByRefreshToken(string refreshToken)
        {
            BaseResponse<User> userResponse = userService.GetUserWithRefreshToken(refreshToken);
            if (userResponse.Success)
            {
                if (userResponse.Extra.RefreshTokenEndDate>DateTime.Now)
                {
                    AccessToken accessToken = tokenHandler.CreateAccessToken(userResponse.Extra);

                    userService.SaveRefreshToken(userResponse.Extra.Id, accessToken.RefreshToken);

                    return new BaseResponse<AccessToken>(accessToken);

                }
                else
                {
                    return new BaseResponse<AccessToken>("refrestoken ın süresi dolmuş");
                }
               
            }
            else
            {
               
                    return new BaseResponse<AccessToken>(userResponse.ErrorMessage);
                
            }
        }

        public BaseResponse<AccessToken> RevokeRefreshRToken(string refreshToken)
        {
            BaseResponse<User> userResponse = userService.GetUserWithRefreshToken(refreshToken);
            if (userResponse.Success)
            {
                tokenHandler.RevokeRefreshToken(userResponse.Extra);
                return new BaseResponse<AccessToken>(new AccessToken());
            }
            else
            {
                return new BaseResponse<AccessToken>("refreshtoken bulunamadı");
            }
         }
    }
}
