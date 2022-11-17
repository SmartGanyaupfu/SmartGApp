using System;
namespace SmartG.Shared.DTOs
{
    public class PostDto:BaseDto
    {
        public Guid PostId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Excerpt { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? Slug { get; set; }
        public int? SgCategoryId { get; set; }
        public int? SgImageId { get; set; }
        public int? SgGalleryId { get; set; }
        public CategoryDto? Category { get; set; }
        public GalleryDto? Gallery { get; set; }
        public ImageDto? Image { get; set; }
        public ICollection<ContentBlockDto>? ContentBlocks { get; set; }
    }
}

