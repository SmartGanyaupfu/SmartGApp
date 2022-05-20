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

        public Guid? PostId { get; set; }
        public Guid? PortfolioId { get; set; }
        public int? PageId { get; set; }
    }
}

