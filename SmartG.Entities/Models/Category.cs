using System;
namespace SmartG.Entities.Models
{
    public class Category:BaseEntity
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public ICollection<Portifolio>? Portifolios { get; set; }

    }
}

