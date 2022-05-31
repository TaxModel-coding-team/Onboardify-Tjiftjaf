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
            Guid id = new Guid("00000000-0000-0000-0000-000000000000");
            if (userViewModel.Id != id)
            {
                List<QuestUserManagement> beginnerQuests = new List<QuestUserManagement>();
                foreach (Quest beginnerquest in _repository.GetAllBeginnerQuests())
                {
                    QuestUserManagement questusermanagement = new QuestUserManagement();
                    questusermanagement.QuestId = beginnerquest.Id;
                    questusermanagement.UserId = userViewModel.Id;
                    beginnerQuests.Add(questusermanagement);
                }
                return _repository.AssignUserQuests(beginnerQuests);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Assigns quests for specific user
        /// </summary>
        /// <param name="questUserViewModel">the Guid from the user and Guid from a quest in a questUserViewmodel</param>
        /// <returns>Boolean true</returns>
        public bool AssignQRQuestForUser(QuestUserViewModel questUserViewModel)
        {
            Guid id = new Guid("00000000-0000-0000-0000-000000000000");
            if (questUserViewModel.UserId != id && questUserViewModel.QuestId != id)
            {
                List<QuestUserManagement> quests = new List<QuestUserManagement>();
                quests.Add(_mapper.Map<QuestUserManagement>(questUserViewModel));
                foreach(QuestUserManagement quest in quests)
                {
                    quest.UserId = questUserViewModel.UserId;
                }
                return _repository.AssignUserQuests(quests);
            }
            else
            {
                return false;
            }
            

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
                Quest quest = _repository.GetQuestById(questUser.QuestId);
                quest.Completed = questUser.Completed;
                quests.Add(quest);
            }
            List<QuestViewModel> questViewModels = _mapper.Map<List<QuestViewModel>>(quests);
            return questViewModels;
        }

        /// <summary>
        /// Updates the quest to be completed.
        /// </summary>
        /// <param name="questToComplete">This is the quest that gets completed</param>
        /// <returns>bool</returns>
        public bool CompleteQuest(QuestUserViewModel questUserViewModel)
        {
            return _repository.CompleteQuest(_mapper.Map<QuestUserManagement>(questUserViewModel));
        }
    }
}
