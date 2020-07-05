using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Domain;
using WebApplication2.Domain.Repositories;
using WebApplication2.Domain.Responses;
using WebApplication2.Domain.Services;
using WebApplication2.Domain.UnitOfWork;

namespace WebApplication2.services
{
    public class UserServices : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserServices(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;

        }


        //----------------------------------------------------


        public BaseResponse<User> adduser(User user)
        {
            try
            {
                 userRepository.adduser(user);
                unitOfWork.Complete();
                return new BaseResponse<User>(user);
            }
            catch (Exception ex)
            {

                return new BaseResponse<User>($"Kişi eklenirken bir hata meydana geldi : {ex.Message}");
            }
        }

        public BaseResponse<User> FindByEmailandPassaword(string email, string passaword)
        {
            try
            {
                User user=userRepository.FindByEmailandPassaword(email, passaword);
                if (user==null)
                {
                    return new BaseResponse<User>("Kullanıcı bulunamadı");
                }
               
                return new BaseResponse<User>(user);
            }
            catch (Exception ex)
            {

                return new BaseResponse<User>($"Email ve şifre aramada bir hata meydana geldi : {ex.Message}");
            }
        }

        public BaseResponse<User> FindById(int userId)
        {
            try
            {
                User user = userRepository.FindById(userId);
                if (user == null)
                {
                    return new BaseResponse<User>("Kullanıcı bulunamadı");
                }
                
                return new BaseResponse<User>(user);
            }
            catch (Exception ex)
            {

                return new BaseResponse<User>($"Kullanıcı bulmada bir hata meydana geldi : {ex.Message}");
            }
        }

        public BaseResponse<User> GetUserWithRefreshToken(string refreshToken)
        {
            try
            {
                User user = userRepository.GetUserWithRefreshToken(refreshToken);
                if (user == null)
                {
                    return new BaseResponse<User>("Kullanıcı bulunamadı");
                }

                return new BaseResponse<User>(user);
            }
            catch (Exception ex)
            {

                return new BaseResponse<User>($"Kullanıcı bulmada bir hata meydana geldi : {ex.Message}");
            }
           

        }

        public void RemoveRefreshToken(User user)
        {
            try
            {
                userRepository.RemoveRefreshToken(user);
                unitOfWork.Complete();
            }
            catch (Exception )
            {

                 //loglama yapılacaktır...
            }
            
        }

        public void SaveRefreshToken(int userId, string refreshToken)
        {
            try
            {
                userRepository.SaveRefreshToken(userId, refreshToken);
                unitOfWork.Complete();
            }
            catch (Exception )
            {

                //loglama yapılacaktır...
            }
        }
    }
}
