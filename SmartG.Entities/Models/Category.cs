using System;
using System.Security.Cryptography.X509Certificates;

namespace SmartG.Entities.Models
{
    public class Category:BaseEntity
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public ICollection<Portfolio>? Portfolios { get; set; }

    }
}