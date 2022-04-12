using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Back_End.Models;

namespace User_Back_End.DAL
{
    public interface IUserRepository
    {
        User GetUser(User user);
        User NewUser(User user);

        User GetUserByID(Guid userId);
    }
}
