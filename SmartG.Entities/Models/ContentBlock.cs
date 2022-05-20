using System;
namespace SmartG.Entities.Models
{
    public class ContentBlock
    {
        public Guid ContentBlockId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        public Guid? PostId { get; set; }
        public Post? Post { get; set; }
        public Guid? PortfolioId { get; set; }
        public Portfolio? Portfolio { get; set; }
        public int? PageId { get; set; }
        public Page? Page { get; set; }
        public Guid? OfferedServiceId { get; set; }
        public OfferedService? Service { get; set; }
    }
}

