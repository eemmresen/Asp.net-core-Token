using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Domain.Responses;

namespace WebApplication2.Domain.Services
{
    public interface IUserService
    {

        BaseResponse<User> adduser(User user);
        BaseResponse<User> FindById(int userId);

        BaseResponse<User> FindByEmailandPassaword(string email, string passaword);

        void SaveRefreshToken(int userId, string refreshToken);

        BaseResponse<User> GetUserWithRefreshToken(string refreshToken);

        void RemoveRefreshToken(User user);
    }
}
