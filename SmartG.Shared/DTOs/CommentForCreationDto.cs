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
        public int CommentId { get; set; }
        public string? Content { get; set; }
        public bool Approved { get; set; }

        public int PostId { get; set; }
    }
}

