using System;
namespace SmartG.Shared.DTOs
{
    public class PostForUpdateDto
    {
        public PostForUpdateDto()
        {
            DateUpdated = DateTime.Now;
        }
        
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Excerpt { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? Slug { get; set; }
        public DateTime? DateUpdated { get; set; }

        
        public string? AuthorId { get; set; }

        public int CategoryId { get; set; }
    }
}

