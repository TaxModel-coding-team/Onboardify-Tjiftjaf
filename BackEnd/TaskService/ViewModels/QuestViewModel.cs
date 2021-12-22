using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.ViewModels
{
    public class QuestViewModel
    {        
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<SubQuestViewModel> SubQuests { get; set; }
    }
}
