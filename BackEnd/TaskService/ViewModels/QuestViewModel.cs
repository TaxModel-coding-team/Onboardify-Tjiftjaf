using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace back_end.ViewModels
{
    public class QuestViewModel
    {        
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Experience { get; set; }
        public virtual ICollection<SubQuestViewModel> SubQuests { get; set; }
    }
}
