using System;
using System.ComponentModel.DataAnnotations;

namespace SmartG.Shared.DTOs
{
    public class UserForAuthDto
    {
        [Required(ErrorMessage = "User name is required")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Password name is required")]
        public string? Password { get; init; }
    }
}

