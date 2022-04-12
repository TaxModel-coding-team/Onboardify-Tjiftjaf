using AutoMapper;
using User_Back_End.ViewModels;
using User_Back_End.Models;

namespace TestProject.Tests
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.Email, o => o.MapFrom(src => src.Email))
                .ForMember(dest => dest.ID, o => o.MapFrom(src => src.ID))
                .ForMember(dest => dest.Username, o => o.MapFrom(src => src.Username));

            CreateMap<UserViewModel, User>()
                .ForMember(dest => dest.Email, o => o.MapFrom(src => src.Email))
                .ForMember(dest => dest.ID, o => o.MapFrom(src => src.ID))
                .ForMember(dest => dest.Username, o => o.MapFrom(src => src.Username));
        }
    }
}