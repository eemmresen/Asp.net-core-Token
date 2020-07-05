using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Domain;
using WebApplication2.Domain.Repositories;
using WebApplication2.Domain.Services;
using WebApplication2.Resources;
using WebApplication2.services;

namespace WebApplication2.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<UserResource, User>();

            CreateMap<User, UserResource>();
        }

       
    }
}
