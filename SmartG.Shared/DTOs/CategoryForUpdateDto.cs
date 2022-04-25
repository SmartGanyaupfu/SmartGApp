using System;
namespace SmartG.Shared.DTOs
{
    public class CategoryForUpdateDto
    {
        public CategoryForUpdateDto()
        {
            DateUpdated = DateTime.Now;
        }
        public DateTime? DateUpdated { get; set; }
        public string? AuthorId { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
    }
}

