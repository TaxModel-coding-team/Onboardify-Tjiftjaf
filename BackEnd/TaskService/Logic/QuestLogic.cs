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
        /// Assigns BeginnerqQuests for specific user
        /// </summary>
        /// <param name="userViewModel">the Guid from the user in a userViewModel</param>
        /// <returns>Boolean true</returns>
        public bool AssignBeginnerQuestForUser(UserViewModel userViewModel)
        {
            List<QuestUserManagement> beginnerQuests = _mapper.Map<List<QuestUserManagement>>(_repository.GetAllBeginnerQuests());
            return _repository.AssignNewUserQuests(beginnerQuests, userViewModel);
        }

        /// <summary>
        /// Assigns quests for specific user
        /// </summary>
        /// <param name="questUserViewModel">the Guid from the user and Guid from a quest in a questUserViewmodel</param>
        /// <returns>Boolean true</returns>
        public bool AssignQRQuestForUser(QuestUserViewModel questUserViewModel)
        {
            return _repository.AssignQRQuest(_mapper.Map<QuestUserManagement>(questUserViewModel));
        }

        /// <summary>
        /// Retrieves quests for specific user
        /// </summary>
        /// <param name="id">the Guid from the user</param>
        /// <returns>List of quests</returns>
        public List<QuestViewModel> GetQuestsByUser(Guid id)
        {
            List<QuestUserManagement> userQuests = _repository.GetQuestsByUser(id).ToList(); 
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
