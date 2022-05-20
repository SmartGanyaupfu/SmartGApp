using System;
namespace SmartG.Shared.DTOs
{
    public class ContentBlockForCreationDto
    {
        
        public string? Title { get; set; }
        public string? Content { get; set; }

        public Guid? PostId { get; set; }
        public Guid? PortfolioId { get; set; }
        public Guid? OfferedServiceId { get; set; }
        public int? PageId { get; set; }
    }
}

