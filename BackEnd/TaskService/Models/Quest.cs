using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Models
{
    public class Quest
    {
        //Properties
        [Key]
        [Required]
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<SubQuest> SubQuests { get; set; }

        public Quest(Guid iD, string title, string description)
        {
            ID = iD;
            Title = title;
            Description = description;
        }

        public Quest()
        {

        }
    }
}
