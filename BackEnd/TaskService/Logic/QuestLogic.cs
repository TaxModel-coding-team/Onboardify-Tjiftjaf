using System;
using System.Collections.Generic;
using System.Linq;
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
        
        //TODO find out what this is.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newUserQuests"></param>
        public void NewUserQuests(List<QuestCompletionViewModel> newUserQuests)
        {
            List<QuestUserManagement> userManagements = _mapper.Map<List<QuestUserManagement>>(newUserQuests);
            _repository.NewUserQuests(userManagements);
        }

        /// <summary>
        /// Gets all the quests from the database
        /// </summary>
        /// <returns>List of all quests</returns>
        public List<QuestViewModel> GetAllQuests()
        {
            List<Quest> quests = _repository.GetAllQuests().ToList();
            List<QuestViewModel> questViewModels = _mapper.Map<List<QuestViewModel>>(quests);

            return questViewModels;
        }

        /// <summary>
        /// Retrieves quests for specific user
        /// </summary>
        /// <param name="guid">the Guid from the user</param>
        /// <returns>List of quests</returns>
        public List<QuestViewModel> GetQuestsByUser(Guid guid)
        {
            List<QuestUserManagement> userQuests = _repository.GetQuestsByUser(guid).ToList(); 
            List<Quest> quests = new List<Quest>();
            
            foreach (QuestUserManagement questUser in userQuests)
            {
                quests.Add(_repository.GetQuestById(questUser.QuestId));
            }
            List<QuestViewModel> questViewModels = _mapper.Map<List<QuestViewModel>>(quests);
            return questViewModels;
        }

        /// <summary>
        /// Updates the quest to be completed.
        /// </summary>
        /// <param name="questToComplete">This is the quest that gets completed</param>
        /// <returns>bool</returns>
        public bool CompleteQuest(QuestCompletionViewModel questToComplete)
        {
            return _repository.CompleteQuest(_mapper.Map<QuestUserManagement>(questToComplete));
        }
    }
}
