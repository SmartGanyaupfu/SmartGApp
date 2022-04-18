using System;
using Microsoft.AspNetCore.Identity;
using SmartG.Shared.DTOs;

namespace SmartG.Service.Contracts
{
    public interface IAuthService
    {
		//istall package Microsoft.AspNetCore.Identity.EntityFrameworkCore and ref proj Shared

		Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
		Task<bool> ValidateUser(UserForAuthDto userForAuth);
		Task<bool> CheckEmailConfirmedAsync(UserForAuthDto userForAuth);

		Task<TokenDto> CreateToken(bool populateExp);
		Task<TokenDto> RefreshToken(TokenDto tokenDto);
		Task<bool> EmailCofirmationAsync(ConfirmEmailDto confirmEmailDto);
		Task<List<UserDto>> GetUsersAsync();
		Task<bool> ResetPasswordAsync(ResetPasswordDto resetPasswordDto);
		Task<bool> ForgotPassworddAsync(ForgotPasswordDto forgotPasswordDto);
		Task<UserDto> GetUserAsync(string Id);
		Task<bool> UpdateUserAsync(UserForUpdateDto userForUpdateDto, string Id);
		Task<bool> DeleteUserAsync(string Id);
	}
}

