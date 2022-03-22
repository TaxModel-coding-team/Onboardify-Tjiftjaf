using System;
using System.Collections.Generic;
using back_end.Models;


namespace back_end.DAL
{
    public interface IQuestRepository
    {
        ICollection<QuestUserManagement> GetQuestsByUser(Guid guid);
        ICollection<SubQuest> GetSubQuestByQuest(Guid guid);
        ICollection<Quest> GetAllQuests();
        Quest GetQuestById(Guid id);
        bool CompleteQuest(QuestUserManagement questToComplete);
    
        void NewUserQuests(List<QuestUserManagement> questUserManagement);
    }
}
