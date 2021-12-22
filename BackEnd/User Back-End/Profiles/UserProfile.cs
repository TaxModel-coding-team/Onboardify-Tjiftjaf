using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Back_End.Models;
using User_Back_End.ViewModels;

namespace User_Back_End.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //source <--> target
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
