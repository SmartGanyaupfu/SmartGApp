using System;
namespace SmartG.Shared.DTOs
{
    public class UserForUpdateDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
       
        public ICollection<RoleDto>? Roles { get; set; }
        public string ImageUrl { get; set; }
    }
}

