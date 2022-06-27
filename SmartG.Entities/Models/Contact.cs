using System;
namespace SmartG.Entities.Models
{
    public class Contact
    {
        public Guid ContactId { get; set; }
        public string? Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public bool OptIn { get; set; }

    }
}

