using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using back_end.Models;
using back_end.ViewModels;

namespace back_end.Profiles
{
    public class QuestProfile : Profile
    {
        public QuestProfile()
        {
            //source <--> target
            CreateMap<Quest, QuestViewModel>().ReverseMap();
            CreateMap<SubQuest, UserViewModel>().ReverseMap();
            //CreateMap<QuestUserManagement, QuestCompletionViewModel>().ReverseMap();
            CreateMap<List<SubQuest>, List<UserViewModel>>().ReverseMap();
        }
        
    }
}
