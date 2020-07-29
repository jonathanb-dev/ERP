using API.DTOs;
using AutoMapper;
using DL.Responses;
using DL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(PostLoginDto postLoginDto)
        {
            LoginResponse loginResponse = await _authService.Login(postLoginDto.Email, postLoginDto.Password);

            UserDto result = _mapper.Map<UserDto>(loginResponse.AppUser);

            return Ok(new { loginResponse.Token, User = result });
        }
    }
}