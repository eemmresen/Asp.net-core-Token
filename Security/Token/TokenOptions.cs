using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Security.Token
{
    public class TokenOptions
    {
        public string Audience { get; set; }//token ı kullanacak sitelerin string ifadesi
        public string Issuer { get; set; }//token ı kim yayacak onun ifadesi



        public int AccessTokenExpiration { get; set; }

        public int RefreshTokenExpiration { get; set; }

        public string SecurityKey { get; set; }

    }
}
