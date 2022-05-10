using System;
namespace SmartG.Shared.DTOs
{
    public class ContentBlockForCreationDto
    {
        
        public string? Title { get; set; }
        public string? Content { get; set; }

        public Guid? PostId { get; set; }
        public Guid? PortifolioId { get; set; }
        public int? PageId { get; set; }
    }
}

