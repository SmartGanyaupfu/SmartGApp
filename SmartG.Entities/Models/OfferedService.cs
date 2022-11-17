using System;
namespace SmartG.Entities.Models
{
    public class OfferedService:BaseEntity
    {
        public Guid OfferedServiceId { get; set; }

        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Excerpt { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? Slug { get; set; }
        public int? SgImageId { get; set; }
        public int? SgGalleryId { get; set; }
        public ICollection<ContentBlock>? ContentBlocks { get; set; }
        
    }
}

