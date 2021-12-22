using ProgressionService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgressionService.DAL
{
    public class AchivementRepository : IAchievementRepository
    {
        private readonly AchievementContext _context;
        public AchivementRepository(AchievementContext context)
        {
            _context = context;
        }
        public ICollection<Achievement> GetAchievements()
        {
            return _context.Achievements.ToList();
        }
    }
}
