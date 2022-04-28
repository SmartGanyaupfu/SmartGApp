using System;
using Microsoft.VisualBasic;

namespace SmartG.Shared.DTOs
{
    public class PortifolioForCreationDto:BaseDto
    {
        public PortifolioForCreationDto()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateAndTime.Now;
            Deleted = false;
        }

        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Excerpt { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? Slug { get; set; }

        public int CategoryId { get; set; }
    }
}

