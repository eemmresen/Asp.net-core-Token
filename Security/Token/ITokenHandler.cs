using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Domain;

namespace WebApplication2.Security.Token
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(User user);


        void RevokeRefreshToken(User user);

    }
}
