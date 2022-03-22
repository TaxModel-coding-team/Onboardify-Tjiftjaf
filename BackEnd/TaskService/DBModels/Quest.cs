using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using User_Back_End.Models;

namespace back_end.Models
{
    public class Quest
    {
        //Properties
        [Key] [Required] public Guid Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        
        // RelationShips
        public virtual ICollection<SubQuest> SubQuests { get; set; }

        public Quest(Guid id, string title, string category, string description, int points)
        {
            Id = id;
            Title = title;
            Category = category;
            Description = description;
            Points = points;
        }
    }
}