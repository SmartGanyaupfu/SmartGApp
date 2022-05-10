using System;
namespace SmartG.Shared.DTOs
{
    public class ContentBlockDto
    {
        public Guid ContentBlockId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        public Guid? PostId { get; set; }
        public Guid? PortifolioId { get; set; }
        public int? PageId { get; set; }
    }
}

