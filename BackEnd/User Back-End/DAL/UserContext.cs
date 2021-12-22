using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Back_End.Models;

namespace User_Back_End.DAL
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().Property(User => User.ID).HasDefaultValueSql("NEWID()");
        }
    }
}
