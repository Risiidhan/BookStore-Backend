using BookStore.application.DTO.AppUser;
using BookStore.application.Interface;
using BookStore.application.Response;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppUserController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AppUserController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserRegisterResponse>> Register([FromBody] RegisterUserDto registerUserDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var createdUser = await _authService.Register(registerUserDto);
            return Ok(createdUser);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequestDto loginUserDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _authService.login(loginUserDto);
            return Ok(user);
        }

    }

}