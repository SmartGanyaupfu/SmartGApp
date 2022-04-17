using System;
namespace SmartG.Entities.Models
{
    public class Page:BaseEntity
    {
        public int PageId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Excerpt { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? slug { get; set; }

    }
}

