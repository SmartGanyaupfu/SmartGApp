using System;
namespace SmartG.Entities.Models
{
    public class Gallery
    {
        public int GalleryId { get; set; }
        public string? Title { get; set; }
        public ICollection<Image>? Images { get; set; }
        
    }
}

