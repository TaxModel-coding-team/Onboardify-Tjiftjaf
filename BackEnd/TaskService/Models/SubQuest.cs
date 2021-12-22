using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Models
{
    public class SubQuest
    {
        [Key]
        public Guid ID { get; set; }
        public string Description { get; set; }
        public int Experience { get; set; }

        [NotMapped]
        public bool Completed { get; set; }

        public SubQuest()
        {

        }
       
    }
}
