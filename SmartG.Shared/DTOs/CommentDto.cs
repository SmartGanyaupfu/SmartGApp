using System;
namespace SmartG.Shared.DTOs
{
    public class CommentDto:BaseDto
    {
        public int CommentId { get; set; }
        public string? Content { get; set; }
        public bool Approved { get; set; }

        public Guid? PostId { get; set; }
        public Guid?PortfolioId { get; set; }
    }
}

