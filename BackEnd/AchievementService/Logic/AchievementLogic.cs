using AutoMapper;
using ProgressionService.DAL;
using ProgressionService.Models;
using ProgressionService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgressionService.Logic
{
    public class AchievementLogic
    {
        private readonly IAchievementRepository _repository;
        private readonly IMapper _mapper;

        public AchievementLogic(IAchievementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ICollection<AchievementViewModel> GetAchievements()
        {
            ICollection<Achievement> achievements = _repository.GetAchievements();
            ICollection<AchievementViewModel> achievementViewModels = _mapper.Map<ICollection<AchievementViewModel>>(achievements);

            return achievementViewModels;
        }
    }
}
