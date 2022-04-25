using System;
namespace SmartG.Shared.DTOs
{
    public class CategoryForCreationDto:BaseDto
    {
        public CategoryForCreationDto()
        {
            DateUpdated = DateTime.Now;
            DateCreated = DateTime.Now;
            Deleted = false;
        }

       
        public string? Name { get; set; }
        public string? Slug { get; set; }
    }
}

