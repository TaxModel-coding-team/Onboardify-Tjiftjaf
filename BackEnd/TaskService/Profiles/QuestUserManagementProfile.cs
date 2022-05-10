using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using back_end.Models;
using back_end.ViewModels;


namespace back_end.Profiles
{
    public class QuestUserManagementProfile : Profile
    {
        public QuestUserManagementProfile(){
            CreateMap<QuestUserViewModel, QuestUserManagement>().ReverseMap();
        }
    }
}
