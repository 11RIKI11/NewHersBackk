using Core.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BackendApp.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class CustomControllerBase : Controller
{
    protected Guid? UserId =>
        Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId) ? userId : null;
    protected IActionResult OkResponse(object data)
    {
        return StatusCode(200, ApiResponse.Success(data));
    }
    protected IActionResult NoContentResponse()
    {
        return StatusCode(200, ApiResponse.Success());
    }
    protected IActionResult BadRequestResponse(string errorMessage = "Validation Error", Dictionary<string, string>? details = null)
    {
        return StatusCode(400, ApiResponse.Failure(errorMessage, 400, details));
    }
    protected IActionResult UnauthorizedResponse()
    {
        return StatusCode(401, ApiResponse.Failure("Unauthorized", 401, null));
    }
    protected IActionResult ForbiddenResponse()
    {
        return StatusCode(403, ApiResponse.Failure("Forbidden", 403, null));
    }
    protected IActionResult NotFoundResponse(string errorMessage = "Not Found", Dictionary<string, string>? details = null)
    {
        return StatusCode(404, ApiResponse.Failure(errorMessage, 404, details));
    }
    protected IActionResult ConflictResponse(string errorMessage = "Conflict", Dictionary<string, string>? details = null)
    {
        return StatusCode(409, ApiResponse.Failure(errorMessage, 409, details));
    }
    protected IActionResult NoAuthorizationResponse(string errorMessage = "Validation Error", Dictionary<string, string>? details = null)
    {
        return StatusCode(401, ApiResponse.Failure(errorMessage, 401, details));
    }
}