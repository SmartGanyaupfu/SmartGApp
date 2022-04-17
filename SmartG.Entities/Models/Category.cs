using System;
namespace SmartG.Entities.Models
{
    public class Category:BaseEntity
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? slug { get; set; }
        public ICollection<Post>? Posts { get; set; }

    }
}

