using System;
namespace SmartG.Shared.DTOs
{
    public class CommentForUpdateDto
    {
        public CommentForUpdateDto()
        {
            DateUpdated = DateTime.Now;
        }

        public DateTime? DateUpdated { get; set; }
        public string? AuthorId { get; set; }
        public string? Content { get; set; }
        public bool Approved { get; set; }

        public Guid? PostId { get; set; }

        public Guid? PortfolioId { get; set; }
    }
}

