using System;
namespace SmartG.Shared.DTOs
{
    public class CommentForCreationDto:BaseDto
    {
        public CommentForCreationDto()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
            Deleted = false;
        }
        
        public string? Content { get; set; }
        public bool Approved { get; set; }
        public Guid? PortifolioId { get; set; }
        public Guid? PostId { get; set; }
    }
}

