using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartG.Entities.Models
{
    public class Portifolio:BaseEntity
    {
        public Guid PortifolioId { get; set; }

        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Excerpt { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? Slug { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }

}


