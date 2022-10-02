using System;
using static System.Net.Mime.MediaTypeNames;

namespace SmartG.Shared.DTOs
{
    public class GalleryForCreationDto
    {

        public string? Title { get; set; }
        public ICollection<ImageForCreationDto>? Images { get; set; }
    }

}