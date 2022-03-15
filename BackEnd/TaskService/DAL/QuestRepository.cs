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

        public void NewUserQuests(List<QuestUserManagement> questUserManagement)
        {
            _context.QuestUserManagement.AddRange(questUserManagement);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets all quests from the user.
        /// </summary>
        /// <param name="guid">from Quest</param>
        /// <returns>List with Quests</returns>
        public ICollection<QuestUserManagement> GetQuestsByUser(Guid guid)
        {
            List<QuestUserManagement> questUserManagement = new List<QuestUserManagement>();
            questUserManagement = _context.QuestUserManagement.Where(u => u.UserId == guid).Include(q => q.QuestId).ToList();

            return questUserManagement;
        }

        /// <summary>
        /// Gets all subQuests from a quest
        /// </summary>
        /// <param name="Id">From the quest</param>
        /// <returns>List with subQuests</returns>
        public ICollection<Quest> GetSubQuestByQuest(Guid Id)
        {
            //List<SubQuest> subQuests = new List<SubQuest>();
            
            /*foreach (SubQuest subQuest in subQuests)
            {
                quests.Add(_context.Quest.Where(q => q.SubQuests.Any(sq => sq.Id == subQuest.Id)).FirstOrDefault());
            }*/
            
            //TODO function for getting stuff from database
            return subQuests;
        }

        public bool CompleteQuest(QuestUserManagement questToComplete)
        {
            QuestUserManagement result = _context.QuestUserManagement.SingleOrDefault(questUser => questUser.UserId == questToComplete.UserId && questUser.SubQuestId == questToComplete.SubQuestId);
            
            if(result != null)
            {
                result.Completed = true;
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
