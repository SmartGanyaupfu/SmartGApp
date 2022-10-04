using System;
using static System.Net.Mime.MediaTypeNames;

namespace SmartG.Shared.DTOs
{
    public class GalleryForUpdateDto
    {
       
        public string? Title { get; set; }
        public ICollection<GalleryImageForUpdateDto>? Images { get; set; }
    }
}

