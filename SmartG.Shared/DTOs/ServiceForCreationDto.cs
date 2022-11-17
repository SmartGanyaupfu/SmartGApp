using System;
using static System.Net.Mime.MediaTypeNames;

namespace SmartG.Shared.DTOs
{
    public class ServiceForCreationDto:BaseDto
    {
        public ServiceForCreationDto()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
            Deleted = false;
        }

        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Excerpt { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? Slug { get; set; }
        public int? SgImageId { get; set; }
        public int? SgGalleryId { get; set; }
        public ICollection<ContentBlockForCreationDto>? ContentBlocks { get; set; }
    }
}

