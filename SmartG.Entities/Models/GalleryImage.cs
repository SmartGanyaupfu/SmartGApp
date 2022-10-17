using System;
namespace SmartG.Entities.Models
{
    public class GalleryImage
    {
        public int Id { get; set; }

        public string? ImageUrl { get; set; }
        public string? AltText { get; set; }
        public string? Caption { get; set; }
        public int GalleryId { get; set; }

    }
}

