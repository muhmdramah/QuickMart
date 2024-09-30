using Core.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuickMart_Ecommerce_API.DTOs.IdentityUser;
using System.Security.Claims;

namespace QuickMart_Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                return Unauthorized();

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
                return Unauthorized();
            else
            {
                return new UserDto()
                {
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user),
                    Name = user.DisplayName,
                };
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterAsync(RegisterDto registerDto)
        {
            var user = new ApplicationUser()
            {
                DisplayName = registerDto.Name,
                Email = registerDto.Email,
                UserName = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
                return BadRequest();

            return new UserDto()
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                Token = _tokenService.CreateToken(user),
            };
        }

        [Authorize]
        [HttpGet("GetCurrentUser")]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var user = await _userManager.FindByEmailAsync(email);

            return new UserDto()
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                Name = user.DisplayName,
            };
        }

        [Authorize]
        [HttpGet("EmailExists")]
        public async Task<ActionResult<bool>> EmailExixts([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) is not null;
        }

        [Authorize]
        [HttpGet("GetCurrentUserAddress")]
        public async Task<ActionResult<Address>> GetUserAddress()
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var user = await _userManager.FindByEmailAsync(email);

            return user.Address;
        }
    }
}
