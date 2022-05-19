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
        public Guid UserId { get; set; }
        public Guid SubQuestId { get; set; }
        public bool Completed { get; set; }
    }
}
