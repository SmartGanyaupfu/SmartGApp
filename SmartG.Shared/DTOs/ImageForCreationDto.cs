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
        public string? ImageUrl { get; set; }
        public string? PublicId { get; set; }
    }
}

