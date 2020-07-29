using BLL.Exceptions;
using DL.Entities;
using DL.Responses;
using DL.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAppUserService _appUserService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthService(IAppUserService appUserService, SignInManager<AppUser> signInManager, IConfiguration configuration)
        {
            _appUserService = appUserService;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<LoginResponse> Login(string email, string password, bool lockoutOnFailure)
        {
            AppUser appUser = await _appUserService.GetUserByEmailAsync(email);

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(appUser, password, lockoutOnFailure);

            if (!result.Succeeded)
                throw new RestException(HttpStatusCode.Unauthorized, new { user = "Invalid credentials" });

            return new LoginResponse
            {
                Token = GenerateJwtToken(appUser),
                AppUser = appUser
            };
        }
        
        public Task Register()
        {
            throw new NotImplementedException();
        }
        
        private string GenerateJwtToken(AppUser appUser)
        {
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()),
                new Claim(ClaimTypes.Name, appUser.UserName)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1D),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}