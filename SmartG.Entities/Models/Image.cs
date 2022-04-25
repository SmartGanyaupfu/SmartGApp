using System;
namespace SmartG.Entities.Models
{
    public class Image:BaseEntity
    {
        public int ImageId { get; set; }
        public string? ImageUrl { get; set; }
        public string? PublicId { get; set; }

    }
}

