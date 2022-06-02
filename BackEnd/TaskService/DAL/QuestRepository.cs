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
            try
            {
                List<Quest> quests = new List<Quest>();
                quests = _context.Quest.Include(q => q.SubQuests).ToList();
                return quests;
            }
            catch (Exception ex)
            {
                List<Quest> quests = new List<Quest>();
                Quest quest = new Quest(new Guid(), null, Convert.ToString(ex), null, 0);
                quests.Add(quest);
                return quests;
            }
     
        }

        public Quest GetQuestById(Guid id)
        {
            try
            {
                return _context.Quest.SingleOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                Quest quest = new Quest(new Guid("00000000-0000-0000-0000-000000000000"), null, Convert.ToString(ex), null, 0);
                return quest;
            }
        }
        
        public void NewUserQuests(List<QuestUserManagement> questUserManagement)
        {
            try
            {
                _context.QuestUserManagement.AddRange(questUserManagement);
                _context.SaveChanges();
            } catch(Exception ex)
            {

            }
        }

        /// <summary>
        /// Gets all quests from the user.
        /// </summary>
        /// <param name="id">From the User</param>
        /// <returns>List with Quests from User</returns>
        public ICollection<QuestUserManagement> GetQuestsByUser(Guid id)
        {
            try{
                List<QuestUserManagement> questUserManagement = new List<QuestUserManagement>();
                questUserManagement = _context.QuestUserManagement.Where(u => u.UserId == id).ToList();

                return questUserManagement;
            }
            catch (Exception ex)
            {
                List<QuestUserManagement> questUserManagement = new List<QuestUserManagement>();
                return questUserManagement;
            }
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
            try
            {
                var Result = _context.QuestUserManagement.Where(o => o.QuestId == questToComplete.QuestId && o.UserId == questToComplete.UserId).First();
                if (Result != null)
                {
                    Result.Completed = true;
                    _context.SaveChanges();
                    return true;
                }
            } catch(Exception ex)
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// Gets all beginner quests
        /// </summary>
        /// <returns>List with subQuests</returns>
        public ICollection<Quest> GetAllBeginnerQuests()
        {
            try
            {
                List<Quest> result = _context.Quest.Where(q => q.Niveau == "Beginner").ToList();
                return result;
            }
            catch (Exception ex)
            {
                List<Quest> fakeresult = new List<Quest>();
                return fakeresult;
            }           
        }

        /// <summary>
        /// Assign new user quests
        /// </summary>
        /// <param name="beginnerQuests">List with quests to assign</param>
        /// <returns>Boolean</returns>
        public bool AssignUserQuests(List<QuestUserManagement> quests)
        {
            try
            {
                foreach (QuestUserManagement quest in quests)
                {
                    if (_context.QuestUserManagement.Any(o => o.QuestId == quest.QuestId && o.UserId == quest.UserId) == false)
                    {
                        _context.QuestUserManagement.Add(quest);
                    }
                }
                var result = _context.SaveChanges();
                if (result != 0 && result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
          
        }
    }
}
