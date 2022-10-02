using System;
using static System.Net.Mime.MediaTypeNames;

namespace SmartG.Shared.DTOs
{
    public class GalleryDto
    {
        public int GalleryId { get; set; }
        public string? Title { get; set; }
        public ICollection<ImageDto>? Images { get; set; }
    }
}

