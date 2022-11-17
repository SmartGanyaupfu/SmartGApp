using System;
using System.ComponentModel.DataAnnotations;

namespace SmartG.Shared.DTOs
{
    public class PageForCreationDto:BaseDto
    {
        public PageForCreationDto()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
            Deleted = false;
        }
        [Required]
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Excerpt { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? Slug { get; set; }
        public int? SgCategoryId { get; set; }
        public int? SgImageId { get; set; }
        public int? SgGalleryId { get; set; }
        public ICollection<ContentBlockForCreationDto>? ContentBlocks { get; set; }
    }
}

