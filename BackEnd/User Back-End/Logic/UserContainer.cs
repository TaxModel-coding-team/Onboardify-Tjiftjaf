using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Back_End.DAL;
using User_Back_End.Models;
using User_Back_End.ViewModels;
using IronBarCode;
using System.Drawing;
using User_Back_End.Logic.LogicInterfaces;

namespace User_Back_End.Logic
{
    public class UserContainer : IUserGetter, IUserSetter
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UserContainer(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public UserViewModel GetUserByID(Guid userId)
        {
            UserViewModel userViewModel = _mapper.Map<UserViewModel>(_repository.GetUserByID(userId));
            return userViewModel;
        }

        public UserViewModel GetUser(UserViewModel userViewModel)
        {
            User user = _mapper.Map<User>(userViewModel);
            userViewModel = _mapper.Map<UserViewModel>(_repository.GetUser(user));
            return userViewModel;
        }

        public UserViewModel NewUser(UserViewModel userViewModel)
        {   
            userViewModel.ExperiencePoints = 0;
            var user = _mapper.Map<User>(userViewModel);
            userViewModel =  _mapper.Map<UserViewModel>(_repository.NewUser(user));
            return userViewModel;
        }
    }
}
