using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Niveau { get; set; }
        [NotMapped] public bool Completed { get; set; }
        
        // Relationships
        public virtual ICollection<SubQuest> SubQuests { get; set; }

        public Quest(Guid id, string title, string category, string description, int points)
        {
            Id = id;
            Title = title;
            Category = category;
            Description = description;
            Points = points;
        }

        public Quest(Guid id, string title, string category, string description, int points, bool completed)
        {
            Id = id;
            Title = title;
            Category = category;
            Description = description;
            Points = points;
            Completed = completed;
        }
        public Quest(Guid id, string title, string category, string description, int points, bool completed, string niveau)
        {
            Id = id;
            Title = title;
            Category = category;
            Description = description;
            Points = points;
            Niveau = niveau;
            Completed = completed;
        }

    }
}