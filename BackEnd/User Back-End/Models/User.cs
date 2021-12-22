using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace User_Back_End.Models
{
    public class User
    {
        [Key]
        [Required]
        public Guid ID { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }


        public User()
        {

        }
        public User(Guid id, string email, string username)
        {
            ID = id;
            Email = email;
            Username = username;
            
        }
        public User(string email)
        {
            Email = email;
        }
        public User(Guid id, string email)
        {

        }
    }
}
