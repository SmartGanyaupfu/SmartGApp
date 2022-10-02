using System;
using static System.Net.Mime.MediaTypeNames;

namespace SmartG.Shared.DTOs
{
    public class GalleryForUpdated
    {
        public int GalleryId { get; set; }
        public string? Title { get; set; }
        public ICollection<ImageForUpdateDto>? Images { get; set; }
    }
}

