using System;
namespace SmartG.Entities.Models
{
    public abstract class BaseEntity
    {
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateUpdated { get; set; } = DateTime.Now;
        public bool? Deleted { get; set; } = false;
        public string? AuthorId { get; set; }

    }
}

