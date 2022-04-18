using System;
namespace SmartG.Entities.Models
{
    public class Comment:BaseEntity
    {
        public int CommentId { get; set; }
        public string? Content { get; set; }
        public bool Approved { get; set; }

        public int PostId { get; set; }

    }
}

