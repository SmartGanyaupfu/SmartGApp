using System;
namespace SmartG.Shared.DTOs
{
    public class TokenDto
    {
        public string? AccessToken { get; init; }
        public string? RefreshToken { get; init; }
        public string? UserName { get; init; }
    }
}

