using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Back_End.Models;

namespace User_Back_End.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }   

        public User GetUser(User user)
        {
            return _context.User.SingleOrDefault(q => q.Email == user.Email);
        }

        public User NewUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
