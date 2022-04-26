using System;
using User_Back_End.ViewModels;

namespace User_Back_End.Logic.LogicInterfaces
{
    public interface IUserGetter
    {
        UserViewModel GetUser(UserViewModel userViewModel);
        UserViewModel GetUserByID(Guid userId);
    }
}
