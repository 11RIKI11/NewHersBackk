using Microsoft.AspNetCore.Mvc;
using Infrastructure.Service;
using Core.Results;
using Core.Attribute;
using Microsoft.AspNetCore.Authorization;
using Core.Model.DTO.Auth;
using Core.Model.DTO.User;
using System.Threading.Tasks;

namespace BackendApp.Controllers
{

    [ApiVersion("1.0")]
    public class AuthController : CustomControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        // Вход в аккаунт
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var result = await _authService.AuthenticateAsync(loginRequest);

            if (!result.IsSuccess)
                return NoAuthorizationResponse(result.Error.ErrorMessage);

            return OkResponse(new { Token = result.Data.token, Role = result.Data.role, UserId = result.Data.id });
        }

        [HttpPost("register")]
        [ValidateModel]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            var result = await _authService.RegisterAsync(registerRequest);

            if (!result.IsSuccess)
                return NoAuthorizationResponse(result.Error.ErrorMessage);

            return OkResponse(new { Token = result.Data.token, Role = result.Data.role, UserId = result.Data.id });
        }

        [HttpPut("change-password")]
        [ValidateModel]
        [ValidateToken]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var result = await _authService.ChangePasswordAsync(UserId.Value, request);
            if (!result.IsSuccess)
                return BadRequestResponse(result.Error.ErrorMessage);
            return NoContent();
        }
    }
}
