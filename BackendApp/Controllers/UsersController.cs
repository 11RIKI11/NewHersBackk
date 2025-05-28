using Microsoft.AspNetCore.Mvc;
using Infrastructure.Service;
using Core.Results;
using Core.Attribute;
using Microsoft.AspNetCore.Authorization;
using Core.Model.DTO.Auth;
using Core.Model.DTO.User;
using System.Threading.Tasks;

namespace BackendApp.Controllers;

[ApiVersion("1.0")]
public class UsersController : CustomControllerBase
{
    private readonly UserService _userService;
    private readonly AuthService _authService;

    public UsersController(UserService userService, AuthService authService)
    {
        _userService = userService;
        _authService = authService;
    }

    // Получить список всех пользователей
    [HttpPost("search")]
    [ValidateModel]
    public async Task<IActionResult> GetAllUsers([FromBody] UserSearchRequest request)
    {
        var result = await _userService.GetUsersAsync(request);
        if(!result.IsSuccess)
            return NotFoundResponse(result.Error.ErrorMessage);
        return OkResponse(result.Data);
    }

    // Получить пользователя по Id
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var result = await _userService.GetUserByIdAsync(id);

        if (!result.IsSuccess)
            return NotFoundResponse(result.Error.ErrorMessage);

        return OkResponse(result.Data);
    }

    [HttpGet("me")]
    [ValidateToken]
    public async Task<IActionResult> GetUserBySelf()
    {
        var result = await _userService.GetUserByIdAsync(UserId.Value);

        if (!result.IsSuccess)
            return NotFoundResponse(result.Error.ErrorMessage);

        return OkResponse(result.Data);
    }

    [HttpPut("{id:guid}")]
    [ValidateModel]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserUpdateRequest userDto)
    {
        var result = await _userService.UpdateUserAsync(id, userDto);

        if (!result.IsSuccess)
            return BadRequestResponse(result.Error.ErrorMessage);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var result = await _userService.DeleteUserAsync(id);
        if (!result.IsSuccess)
            return NotFoundResponse(result.Error.ErrorMessage);
        return NoContent();
    }
}
