using System;
namespace SmartG.Shared.DTOs
{
    public class PortfolioForUpdateDto
    {
        public PortfolioForUpdateDto()
        {
            DateUpdated = DateTime.Now;
        }

        public DateTime? DateUpdated { get; set; }
        public string? AuthorId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Excerpt { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? Slug { get; set; }


        public int CategoryId { get; set; }
        public int? ImageId { get; set; }


    }
}

