using System;
using System.ComponentModel.DataAnnotations;

namespace User_Back_End.Models
{
    public class Organisation
    {
        [Key]
        public Guid OrganisationId { get; set; }
        public string Name { get; set; }

        public Organisation(Guid organisationId, string name)
        {
            OrganisationId = organisationId;
            Name = name;
        }
    }
}