using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgressionService.Models
{
    public class Achievement
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconName { get; set; }
    }
}
