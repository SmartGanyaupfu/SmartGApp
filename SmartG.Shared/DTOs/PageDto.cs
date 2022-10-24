using System;
namespace SmartG.Shared.DTOs
{
    public class PageDto:BaseDto
    {
        public int PageId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Excerpt { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? Slug { get; set; }
        public int? ImageId { get; set; }
        public ImageDto? Image { get; set; }
        public ICollection<ContentBlockDto>? ContentBlocks { get; set; }
        public int? GalleryId { get; set; }
        public GalleryDto? Gallery { get; set; }
    }
}

