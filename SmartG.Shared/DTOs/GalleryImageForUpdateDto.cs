using System;
namespace SmartG.Shared.DTOs
{
    public class GalleryImageForUpdateDto
    {
      
        public string? ImageUrl { get; set; }
        public string? AltText { get; set; }
        public string? Caption { get; set; }
        public int? GalleryId { get; set; }
    }
}

