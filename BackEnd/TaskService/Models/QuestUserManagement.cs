using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Models
{
    public class QuestUserManagement
    {
        [Key]
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid SubQuestID { get; set; }
        public virtual SubQuest SubQuests {get; set; }
        public bool Completed { get; set; }
    }
}
