using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using back_end.DAL;
using back_end.Models;
using back_end.ViewModels;

namespace back_end.Logic
{
    public class QuestLogic
    {
        private readonly IQuestRepository _repository;
        private readonly IMapper _mapper;

        public QuestLogic(IQuestRepository repository, IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }

        public void NewUserQuests(List<QuestCompletionViewModel> newUserQuests)
        {
            List<QuestUserManagement> userManagements = _mapper.Map<List<QuestUserManagement>>(newUserQuests);
            _repository.NewUserQuests(userManagements);
        }

        public List<QuestViewModel> GetAllQuests()
        {
            List<Quest> quests = _repository.GetAllQuests().ToList();
            List<QuestViewModel> questViewModels = _mapper.Map<List<QuestViewModel>>(quests);

            return questViewModels;
        }

        public List<QuestViewModel> GetQuestsByUser(Guid guid)
        {
            List<QuestUserManagement> questsUsers = _repository.GetSubQuestsByUser(guid).ToList();

            foreach (QuestUserManagement quest in questsUsers)
            {
                quest.SubQuests.Completed = quest.Completed;
            }

            List<Quest> quests = _repository.GetQuestBySubQuest(questsUsers.Select(q => q.SubQuests).ToList()).ToList();
            List<QuestViewModel> questViewModels = _mapper.Map<List<QuestViewModel>>(quests);

            return questViewModels;
        }

        public bool CompleteQuest(QuestCompletionViewModel questToComplete)
        {
            return _repository.CompleteQuest(_mapper.Map<QuestUserManagement>(questToComplete));
        }
    }
}
