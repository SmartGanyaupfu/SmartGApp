using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartG.Entities.Models
{
    public class Comment:BaseEntity
    {
        [Key]
        public int CommentId { get; set; }
        public string? Content { get; set; }
        public bool Approved { get; set; }

        public Guid? PostId { get; set; }
        public Post? Post { get; set; }
        public Guid? PortifolioId { get; set; }
        public Portifolio? Portifolio { get; set; }

    }

}

