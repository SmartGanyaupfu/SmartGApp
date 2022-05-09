using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartG.Entities.Models
{
    
    public class Image:BaseEntity
    {
        public int ImageId { get; set; }
        public string? ImageUrl { get; set; }
        public string? PublicId { get; set; }

        public Guid? PostId { get; set; }
        public Post? Post { get; set; }
        public Guid? PortifolioId { get; set; }
        public Portifolio? Portifolio { get; set; }
        public int? PageId { get; set; }
        public Page?  Page { get; set; }

    }
}

