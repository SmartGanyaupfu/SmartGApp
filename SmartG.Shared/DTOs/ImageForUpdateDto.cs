using System;
namespace SmartG.Shared.DTOs
{
    public class ImageForUpdateDto
    {
        public ImageForUpdateDto()
        {
        }

        public int ImageId { get; set; }
        public string? ImageUrl { get; set; }
        public string? PublicId { get; set; }

    }
}

