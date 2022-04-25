using System;
namespace SmartG.Shared.DTOs
{
    public class PortifolioForUpdateDto
    {
        public PortifolioForUpdateDto()
        {
        }
       

        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Excerpt { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? Slug { get; set; }
        public ImageDto? Image { get; set; }
    }
}

