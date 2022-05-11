using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using back_end.Logic;
using Microsoft.AspNetCore.Razor.Language;

namespace back_end.DAL
{
    public class QuestRepository : IQuestRepository
    {
        private readonly QuestContext _context;

        public QuestRepository(QuestContext context)
        {
            _context = context;
        }

        public ICollection<Quest> GetAllQuests()
        {
            List<Quest> quests = new List<Quest>();
            quests = _context.Quest.Include(q => q.SubQuests).ToList();

            return quests;
        }

        public Quest GetQuestById(Guid id)
        {
            return _context.Quest.SingleOrDefault(x => x.Id == id);
        }
        
        public void NewUserQuests(List<QuestUserManagement> questUserManagement)
        {
            _context.QuestUserManagement.AddRange(questUserManagement);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets all quests from the user.
        /// </summary>
        /// <param name="id">From the User</param>
        /// <returns>List with Quests from User</returns>
        public ICollection<QuestUserManagement> GetQuestsByUser(Guid id)
        {
            List<QuestUserManagement> questUserManagement = new List<QuestUserManagement>();
            questUserManagement = _context.QuestUserManagement.Where(u => u.UserId == id).ToList();

            return questUserManagement;
        }

        /// <summary>
        /// Gets all subQuests from a quest
        /// </summary>
        /// <param name="id">From the quest</param>
        /// <returns>List with subQuests</returns>
        public ICollection<SubQuest> GetSubQuestByQuest(Guid id)
        {
            //List<SubQuest> subQuests = new List<SubQuest>();
            
            /*foreach (SubQuest subQuest in subQuests)
            {
                quests.Add(_context.Quest.Where(q => q.SubQuests.Any(sq => sq.Id == subQuest.Id)).FirstOrDefault());
            }*/
            
            //TODO function for getting stuff from database
            //return subQuests;
            throw new NotImplementedException();
        }

        public bool CompleteQuest(QuestUserManagement questToComplete)
        {
            QuestUserManagement result = _context.QuestUserManagement.SingleOrDefault(questUser => questUser.UserId == questToComplete.UserId && questUser.QuestId == questToComplete.QuestId);
            
            if(result != null)
            {
                result.Completed = true;
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets all beginner quests
        /// </summary>
        /// <returns>List with subQuests</returns>
        public ICollection<Quest> GetAllBeginnerQuests()
        {
            List<Quest> result = _context.Quest.Where(q => q.Niveau == "Beginner").ToList();
            return result;
            
        }

        /// <summary>
        /// Assign new user quests
        /// </summary>
        /// <param name="beginnerQuests">List with quests to assign</param>
        /// <returns>Boolean</returns>
        public bool AssignUserQuests(List<QuestUserManagement> quests)
        {
            foreach(QuestUserManagement quest in quests)
            {
                _context.QuestUserManagement.Add(quest);
            }
            var result =_context.SaveChanges();
            if(result != 0 && result < 0)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }

        /// <summary>
        /// Assign one quest to a user
        /// </summary>
        /// <param name="questUserManagement">From the quest</param>
        /// <returns>List with subQuests</returns>
        public bool AssignQRQuest(QuestUserManagement questUserManagement)
        {
            _context.QuestUserManagement.Add(questUserManagement);
            var result = _context.SaveChanges();
            if (result != 0 && result < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
