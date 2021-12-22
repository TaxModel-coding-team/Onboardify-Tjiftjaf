using AutoMapper;
using ProgressionService.Models;
using ProgressionService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgressionService.Profiles
{
    public class AchievementProfile : Profile
    {
        public AchievementProfile()
        {
            CreateMap<Achievement, AchievementViewModel>().ReverseMap();
        }
    }
}
