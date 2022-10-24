using System;
using Microsoft.VisualBasic;

namespace SmartG.Shared.DTOs
{
    public class PostForCreationDto:BaseDto
    {
        public PostForCreationDto()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateAndTime.Now;
            Deleted = false;
        }
        
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Excerpt { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? Slug { get; set; }
        public int? ImageId { get; set; }
        public int CategoryId { get; set; }
        public ICollection<ContentBlockForCreationDto>? ContentBlocks { get; set; }
        public int? GalleryId { get; set; }
    }
}

