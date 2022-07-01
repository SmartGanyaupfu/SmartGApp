using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartG.Contracts;
using SmartG.Entities.Models;
using SmartG.Service.Contracts;
using SmartG.Shared.DTOs;

namespace SmartG.Service
{
    public class AuthService : IAuthService
    {
        //install packages AutoMapper.Extensions.Microsoft.DependencyInjection and Jwt tokens and ref email service nad service contracts
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailService;
        private User _user;

        public AuthService(ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration, IEmailSender emailSenderService)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _emailService = emailSenderService;
        }

        public async Task<TokenDto> CreateToken(bool populateExp)
        {
            var siginingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(siginingCredentials, claims);
            //return new JwtSecurityTokenHandler().WriteToken(TokenOptions);
            //return new JwtSecurityTokenHandler().CreateToken(TokenOptions).Write
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenOptions);
            //return tokenHandler.WriteToken(token);

            var refreshToken = GenerateRefreshToken();
            _user.RefreshToken = refreshToken;

            if (populateExp)
                _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(1);
            await _userManager.UpdateAsync(_user);
            var accessToken = tokenHandler.WriteToken(token);
            return new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                UserName = _user.UserName
            };
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            List<UserDto> userDto = new List<UserDto>();
            //var all = users.Where(x=>x.Role)

            var allRoles = new List<string>();
            var roleValues = Enum.GetNames(typeof(MyRolesEnum));
            foreach (var roleEnum in roleValues)
            {
                allRoles.Add(roleEnum);

            }



            foreach (User user in users)
            {
                var activatedRoles = new List<RoleDto>();
                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var r in allRoles)
                {
                    var isMyRole = allRoles.Select(x => userRoles.Any(b => r == b)).FirstOrDefault();
                    if (isMyRole)
                    {
                        activatedRoles.Add(new RoleDto() { Name = r, IsActive = true });
                    }
                    else
                    {
                        activatedRoles.Add(new RoleDto() { Name = r, IsActive = false });
                    }


                }

                userDto.Add(new UserDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                   
                    Roles = activatedRoles,
                    Id = user.Id

                });

            }

            return userDto;
        }

        public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);
            var x = principal.Identity.Name;
            var user = await _userManager.FindByNameAsync(principal.Identity.Name);
            if (user == null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                throw new Exception("Invalid Request, Token Invalid");// You can create a token bad request
            _user = user;
            return await CreateToken(populateExp: false);
        }

        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);

            var roles = new List<string>();
            if (userForRegistration.Roles != null)
            {
                foreach (var role in userForRegistration.Roles)
                {
                    if (role.IsActive && Enum.GetNames(typeof(MyRolesEnum)).Contains(role.Name))
                    {
                        roles.Add(role.Name);
                    }
                }
            }
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var param = new Dictionary<string, string>
            {
                {"token",token },
                {"email",user.Email }
            };

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, roles);

                var callback = QueryHelpers.AddQueryString(userForRegistration.ClientURI, param);
                var message = new EmailMessageDto(new string[] { user.Email }, "Email Confirmation token", "Hi " + user.UserName + "<br> Your account has bee created " +
            "using this email, click on  the link to verify your email \n <a href=\"" +callback+ " \">Verify Eamil</a> You can copy the link below directly to your browser." + callback +" If you did not request, kindly ignore the email."+
            "<br>Thanks Digital Team.");
                await _emailService.SendEmailAsync(message);

            }

            return result;
        }

        public async Task<bool> ValidateUser(UserForAuthDto userForAuth)
        {
            _user = await _userManager.FindByNameAsync(userForAuth.UserName);


            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password));
            if (!result)
                _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed. Wrong user name or password.");

            return result;
        }

        private SecurityTokenDescriptor GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            /*var tokenOptions = new JwtSecurityToken(
           
                issuer: jwtSettings.GetSection("validIssuer").Value,
                audience: jwtSettings.GetSection("validAudience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("expires").Value)),
                signingCredentials: signingCredentials);
            */
            var tokenOptions = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = jwtSettings.GetSection("validIssuer").Value,
                Audience = jwtSettings.GetSection("validAudience").Value,

                Expires = DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("expires").Value)),
                SigningCredentials = signingCredentials

            };



            return tokenOptions;
        }

        private SigningCredentials GetSigningCredentials()
        {
            //var jwtSettings = _configuration.GetSection("JwtSettings");
            /*var tokenOptions = new JwtSecurityToken(
           
                issuer: jwtSettings.GetSection("validIssuer").Value

            */
            var keyValue = _configuration.GetSection("SecretKey").Value;
            var key = Encoding.UTF8.GetBytes(keyValue);
            // var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {


                new Claim(JwtRegisteredClaimNames.GivenName,_user.UserName),
                new Claim(JwtRegisteredClaimNames.Email,_user.Email),
                new Claim(ClaimTypes.Name,_user.UserName),
                new Claim(ClaimTypes.NameIdentifier, _user.Id)
            };
            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {

                claims.Add(new Claim(ClaimTypes.Role, role));

            }
            return claims;

            // var roles = await _userManager.GetRolesAsync(_user); foreach (var role in roles) { claims.Add(new Claim(ClaimTypes.Role, role)); }
        }
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var keyValue = _configuration.GetSection("SecretKey").Value;
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyValue)),
                ValidateLifetime = false,
                ValidIssuer = jwtSettings["validIssuer"],
                ValidAudience = jwtSettings["validAudience"]
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public async Task<bool> CheckEmailConfirmedAsync(UserForAuthDto userForAuth)
        {
            _user = await _userManager.FindByNameAsync(userForAuth.UserName);


            var result = (_user != null && await _userManager.IsEmailConfirmedAsync(_user));
            if (!result)
                _logger.LogWarn($"{nameof(CheckEmailConfirmedAsync)}: Email is not confirmed");

            return result;
        }

        public async Task<bool> EmailCofirmationAsync(ConfirmEmailDto confirmEmailDto)
        {
            var user = await _userManager.FindByEmailAsync(confirmEmailDto.Email);

            var confirmResult = await _userManager.ConfirmEmailAsync(user, confirmEmailDto.Token);
            if (confirmResult.Succeeded)
                return true;
            return confirmResult.Succeeded;
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordDto resetPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
            if (user == null)
                return false;

            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.Password);
            return resetPassResult.Succeeded;
        }

        public async Task<bool> ForgotPassworddAsync(ForgotPasswordDto forgotPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
            if (user is null)
            {
                return false;
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var param = new Dictionary<string, string>
                {
                    {"token",token },
                    {"email", forgotPasswordDto.Email }
                };
            var callback = QueryHelpers.AddQueryString(forgotPasswordDto.ClientURI, param);
            var message = new EmailMessageDto(new string[] { user.Email }, "Reset password token", "Hi " + user.UserName + "<br>" + " You requested a " +
            "password reset, The link to reset your password is <a href=\"" + callback + " \">Reset Password</a> You can copy the link below directly to your browser."
            + callback + "   < br> If you did not request, kindly ignore the email. Thanks,  Digital Team.");
            await _emailService.SendEmailAsync(message);

            return true;
        }

        public async Task<UserDto> GetUserAsync(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            var allRoles = new List<string>();
            var roleValues = Enum.GetNames(typeof(MyRolesEnum));
            foreach (var roleEnum in roleValues)
            {
                allRoles.Add(roleEnum);

            }
            var activatedRoles = new List<RoleDto>();
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var r in allRoles)
            {
                var isMyRole = allRoles.Select(x => userRoles.Any(b => r == b)).FirstOrDefault();
                if (isMyRole)
                {
                    activatedRoles.Add(new RoleDto() { Name = r, IsActive = true });
                }
                else
                {
                    activatedRoles.Add(new RoleDto() { Name = r, IsActive = false });
                }

            }
            var userToReturn = new UserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Roles = activatedRoles,
                Id = user.Id
            };
            return userToReturn;
        }
        public async Task<bool> UpdateUserAsync(UserForUpdateDto userForUpdateDto, string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                _logger.LogInfo($"User with ID : {Id} does not exist");

            }

            _mapper.Map(userForUpdateDto, user);

            var result = await _userManager.UpdateAsync(user);

            var roles = new List<string>();
            if (userForUpdateDto.Roles != null)
            {
                foreach (var role in userForUpdateDto.Roles)
                {
                    if (role.IsActive && Enum.GetNames(typeof(MyRolesEnum)).Contains(role.Name))
                    {
                        roles.Add(role.Name);
                    }
                }
            }
            if (result.Succeeded)
            {
                await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
                await _userManager.AddToRolesAsync(user, roles);
            }
            return result.Succeeded;
        }

        public async Task<bool> DeleteUserAsync(string Id)
        {
            var userToDelete = await _userManager.FindByIdAsync(Id);
            if (userToDelete == null)
            {
                _logger.LogInfo($"User with ID : {Id} does not exist");
                return false;
            }
            var result = await _userManager.DeleteAsync(userToDelete);

            return result.Succeeded;
        }
    }
}

