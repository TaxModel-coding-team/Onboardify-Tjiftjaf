using System;
using User_Back_End.ViewModels;

namespace User_Back_End.Logic.LogicInterfaces
{
    public interface IUserLogic
    {
        UserViewModel GetUser(UserViewModel userViewModel);
        UserViewModel GetUserByID(Guid userId);
        UserViewModel NewUser(UserViewModel userViewModel);
    }
}
