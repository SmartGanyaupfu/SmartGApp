using System;
namespace SmartG.Shared.DTOs
{
    public class UserDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        
        public ICollection<RoleDto>? Roles { get; set; }
        public string? ImageUrl { get; set; }
    }
}

