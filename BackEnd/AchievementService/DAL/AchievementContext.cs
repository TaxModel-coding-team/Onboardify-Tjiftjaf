using Microsoft.EntityFrameworkCore;
using ProgressionService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgressionService.DAL
{
    public class AchievementContext : DbContext
    {
        public AchievementContext(DbContextOptions<AchievementContext> options) : base(options)
        {

        }

        public virtual DbSet<Achievement> Achievements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Achievement>().Property(Achievement => Achievement.ID).HasDefaultValueSql("NEWID()");
        }
    }
}
