using ProgressionService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgressionService.DAL
{
    public interface IAchievementRepository
    {
        ICollection<Achievement> GetAchievements();
    }
}
