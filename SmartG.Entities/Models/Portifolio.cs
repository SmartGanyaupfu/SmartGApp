using System;
namespace SmartG.Entities.Models
{
    public class Portifolio:BaseEntity
    {
        public int PortifolioId { get; set; }

        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Excerpt { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? Slug { get; set; }
        public Image? Image { get; set; }
        public Category? Category { get; set; }

    }
}

