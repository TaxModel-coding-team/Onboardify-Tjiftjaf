using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.ViewModels
{
    public class QuestCompletionViewModel
    {
        [Required]
        public Guid UserID { get; set; }
        [Required]
        public Guid SubQuestID { get; set; }
        public bool Completed { get; set; }
    }
}
