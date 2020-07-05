using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Security.Token;

namespace WebApplication2.Domain.Repositories
{
    public class UserRepository : BaseRepository,IUserRepository
    {
        private readonly TokenOptions tokenOptions;
      
        public UserRepository(UdemyApiWithTokenDBContext context, IOptions< TokenOptions >tokenOptions) : base(context) 
        {
            this.tokenOptions = tokenOptions.Value;
        
        
        }
       
        public void adduser(User user)
        {
              context.User.Add(user);
        }

        public User FindByEmailandPassaword(string email, string passaword)
        {
           return context.User.Where(u => u.Email == email && u.Password == passaword).FirstOrDefault();
        }

        public User FindById(int userId)
        {
            return context.User.Find(userId);
        }

        

        public User GetUserWithRefreshToken(string refreshToken)
        {
            return context.User.FirstOrDefault(u => u.RefreshToken == refreshToken);
        }

        public void RemoveRefreshToken(User user)
        {
            
            User newuser = this.FindById(user.Id);
            newuser.RefreshToken = null;
            newuser.RefreshTokenEndDate = null;
        }

       

        public void SaveRefreshToken(int userId, string refreshToken)
        {
            User newuser = this.FindById(userId);
            newuser.RefreshToken = refreshToken;
            newuser.RefreshTokenEndDate = DateTime.Now.AddDays(tokenOptions.RefreshTokenExpiration);
        }
    }
}
