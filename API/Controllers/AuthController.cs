using API.Services;
using App.DTO;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AuthController : ApiController
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;
        public AuthController(ITokenService tokenService, UserManager<User> userManager)

        {
            _tokenService = tokenService;
            _userManager = userManager;
        }

        [HttpPost("Signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto signUpDto)
        {
            var match = await _userManager.FindByEmailAsync(signUpDto.Email);
            if (match is not null) return BadRequest( new ResponseDto<string>(null, false, "Email already register"));
            var user = new User()
            {
                Email = signUpDto.Email,
                UserName = signUpDto.Username
            };
            var result = await _userManager.CreateAsync(user, signUpDto.Password);
            if (result.Errors.Count() > 0) return BadRequest(new ResponseDto<string>(null, false, result.Errors.Select( err=>err.Description).ToArray() ));
            var token = _tokenService.CreateToken(user);
            return Ok(new ResponseDto<string>(token) );
        }

        [HttpGet("hello")]
        public IActionResult GetHello()
        {
            return Ok("hello");
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInDto signInDto)
        {
            var match = await _userManager.FindByEmailAsync(signInDto.Email);
            if (match is null) return BadRequest(new ResponseDto<string>(null, false, "Bad credentials"));
            var result = await _userManager.CheckPasswordAsync(match, signInDto.Password);
            if(!result) return BadRequest(new ResponseDto<string>(null, false, "Bad credentials"));
            var token = _tokenService.CreateToken(match);
            return Ok(new ResponseDto<string>(token));
        }
    }
}
