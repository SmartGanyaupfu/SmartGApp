using System;
namespace SmartG.Shared.DTOs
{
    public class ImageForCreationDto:BaseDto
    {
        public ImageForCreationDto()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
            Deleted = false;
        }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? PublicId { get; set; }
        public string? AltText { get; set; }
        public string? Caption { get; set; }
    }
}

