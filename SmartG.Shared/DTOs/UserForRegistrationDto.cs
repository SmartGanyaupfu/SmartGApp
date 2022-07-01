using System;
using System.ComponentModel.DataAnnotations;

namespace SmartG.Shared.DTOs
{
    public class UserForRegistrationDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<RoleDto>? Roles { get; set; }
        [Required(ErrorMessage = "Client URI is required")]
        public string? ClientURI { get; set; }

       
    }
}

