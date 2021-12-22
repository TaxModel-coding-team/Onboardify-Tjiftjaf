using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end.Models;


namespace back_end.DAL
{
    public interface IQuestRepository
    {
        ICollection<QuestUserManagement> GetSubQuestsByUser(Guid guid);
        ICollection<Quest> GetQuestBySubQuest(List<SubQuest> subQuests);
        ICollection<Quest> GetAllQuests();
        bool CompleteQuest(QuestUserManagement questToComplete);

        void NewUserQuests(List<QuestUserManagement> questUserManagement);
    }
}
