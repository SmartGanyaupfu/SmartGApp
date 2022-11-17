using System;
using Microsoft.VisualBasic;

namespace SmartG.Shared.DTOs
{
    public class PortfolioForCreationDto:BaseDto
    {
        public PortfolioForCreationDto()
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

        public int? SgCategoryId { get; set; }
        public int? SgImageId { get; set; }
        public int? SgGalleryId { get; set; }
        public ICollection<ContentBlockForCreationDto>? ContentBlocks { get; set; }
    }
}

