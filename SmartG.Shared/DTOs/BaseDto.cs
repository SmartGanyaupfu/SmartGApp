using System;
namespace SmartG.Shared.DTOs
{
    public class BaseDto
    {
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; } 
        
        public bool? Deleted { get; set; } = false;
        public string? AuthorId { get; set; }
    }
}

