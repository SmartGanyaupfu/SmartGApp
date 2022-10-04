using System;
using static System.Net.Mime.MediaTypeNames;

namespace SmartG.Shared.DTOs
{
    public class GalleryForCreationDto
    {

        public string? Title { get; set; }
        public ICollection<GalleryImageForCreationDto>? Images { get; set; }
    }

}