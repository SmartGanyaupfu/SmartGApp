﻿using System;
namespace SmartG.Shared.DTOs
{
    public class PostDto:BaseDto
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Excerpt { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? Slug { get; set; }

        public CategoryDto? Category { get; set; }
        public int CategoryId { get; set; }
    }
}

