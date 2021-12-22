using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.ViewModels
{
    public class SubQuestViewModel
    {
        public Guid ID { get; set; }
        public string Description { get; set; }
        public int Experience { get; set; }
        public bool Completed { get; set; }
    }
}
