using System;
namespace SmartG.Shared.DTOs
{
    public class ImageDto:BaseDto
    {
        
        public int ImageId { get; set; }
        public string? ImageUrl { get; set; }
        public string ?PublicId { get; set; }
    }
}

