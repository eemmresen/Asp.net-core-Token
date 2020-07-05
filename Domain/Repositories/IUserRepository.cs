using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Domain.Repositories
{
    public interface IUserRepository
    {
        void adduser(User user);
        User FindById(int userId);

        User FindByEmailandPassaword(string email, string passaword);

        void SaveRefreshToken(int userId, string refreshToken);

        User GetUserWithRefreshToken(string refreshToken);

        void RemoveRefreshToken(User user);
    }
}
