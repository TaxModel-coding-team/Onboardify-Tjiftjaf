using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Models
{
    public class QuestUserManagement
    {
        public Guid UserId { get; set; }
        public Guid QuestId { get; set; }
        public bool Completed { get; set; }
        
        public QuestUserManagement(){
    
        }

        public QuestUserManagement(Guid userId, Guid questId, bool completed)
        {
            UserId = userId;
            QuestId = questId;
            Completed = completed;
        }
    }
    
}
