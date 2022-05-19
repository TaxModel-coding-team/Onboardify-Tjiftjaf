using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Back_End.ViewModels;

namespace User_Back_End.Logic.LogicInterfaces
{
    public interface IUserSetter
    {
        UserViewModel NewUser(UserViewModel userViewModel);
    }
}
