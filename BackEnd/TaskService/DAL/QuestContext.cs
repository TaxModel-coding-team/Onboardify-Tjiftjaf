using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end.Models;

namespace back_end.DAL
{
    public class QuestContext : DbContext
    {
        public QuestContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Quest> Quest { get; set; }
        public virtual DbSet<SubQuest> SubQuest { get; set; }
        public virtual DbSet<QuestUserManagement> QuestUserManagement { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    
            modelBuilder.Entity<Quest>().Property(Quest => Quest.ID).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<SubQuest>().Property(SubQuest => SubQuest.ID).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<QuestUserManagement>().Property(QuestUserManagement => QuestUserManagement.ID).HasDefaultValueSql("NEWID()");
        }
    }
}
