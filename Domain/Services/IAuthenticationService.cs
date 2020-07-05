using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Domain.Responses;
using WebApplication2.Security.Token;

namespace WebApplication2.Domain.Services
{
    public interface IAuthenticationService
    {
        BaseResponse<AccessToken> CreateAccessToken(string Email, string Password);

        BaseResponse<AccessToken> CreateAccessTokenByRefreshToken(string refreshToken);

        BaseResponse<AccessToken> RevokeRefreshRToken(string refreshToken);


    }
}
