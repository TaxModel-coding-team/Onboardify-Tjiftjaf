using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace back_end.Models
{
    public class Quest
    {
        //Properties
        [Key] [Required] public Guid Id { get; set; }
        public Guid OrganisationId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public virtual ICollection<SubQuest> SubQuests { get; set; }
        
        public Quest(Guid id, Guid organisationId, string title, string category, string description, int points)
        {
            Id = id;
            Title = title;
            Category = category;
            Description = description;
            Points = points;
            OrganisationId = organisationId;
        }

        public Quest()
        {
        }
    }
}