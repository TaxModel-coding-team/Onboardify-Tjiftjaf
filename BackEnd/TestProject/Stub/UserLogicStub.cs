using System;
using System.Collections.Generic;
using System.Text;
using User_Back_End.ViewModels;

namespace TestProject.Stub
{
    public class UserLogicStub : User_Back_End.Logic.LogicInterfaces.IUserLogic
    {
        public List<UserViewModel> viewModels;

        public void SetUsers(List<UserViewModel> viewModels)
        {
            this.viewModels = viewModels;
        }
        public UserViewModel GetUser(UserViewModel userViewModel)
        {
            return new UserViewModel();
        }

        public UserViewModel GetUserByID(Guid userId)
        {
            return viewModels.Find(u => u.ID == userId);
        }

        public UserViewModel NewUser(UserViewModel userViewModel)
        {
            return new UserViewModel();
        }

        
    }
}
