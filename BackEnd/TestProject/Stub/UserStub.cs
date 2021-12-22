using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Back_End.DAL;
using User_Back_End.Models;

namespace TestProject.Stub
{
    public class UserStub : IUserRepository
    {
        public List<User> Tests = new List<User>();

        public User NewUser(User user)
        {
            Tests.Add(new User(new Guid("BD738E5E-D298-4005-BABE-3FA8E7656C00"), "MaxCool@hotmail.com", "MaxCool"));
            if (user.Username != null)
            {
                Tests.Add(user);
                return user;
            }
            if (Tests == null)
            {
                throw new NullReferenceException("Failed to return a value.");
            }
            return Tests[0];
        }

        public User GetUser(User user)
        {
            Tests.Add(new User(new Guid("55358E6B-D4AE-4293-A493-1061FBD36B7A"), "464748@student.fontys.nl", "jitske"));
            if(Tests == null)
            {
                throw new NullReferenceException("Failed to return a value.");
            }

            foreach(User test in Tests)
            {
                if(user.ID == test.ID)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
