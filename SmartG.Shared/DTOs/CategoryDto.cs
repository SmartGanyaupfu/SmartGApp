using System;
namespace SmartG.Shared.DTOs
{
    public class CategoryDto:BaseDto
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
    }
}

