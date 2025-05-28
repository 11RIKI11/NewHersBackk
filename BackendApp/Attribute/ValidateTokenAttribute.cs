using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Core.Results;

namespace Core.Attribute
{
    public class ValidateTokenAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
            {
                context.Result = new UnauthorizedObjectResult(ApiResponse.Failure("Token is missing or invalid", 401));
                return;
            }

 
            var token = authorizationHeader.Replace("Bearer ", "");

            try
            {
   
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                {
                    context.Result = new UnauthorizedObjectResult(ApiResponse.Failure("Invalid token format", 401));
                    return;
                }

                // Извлекаем userId из токена
                var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "nameid");
                if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out _))
                {
                    context.Result = new UnauthorizedObjectResult(ApiResponse.Failure("Invalid token: userId is missing or invalid", 401));
                    Console.WriteLine("123");
                    return;
                }
            }
            catch (Exception)
            {
                context.Result = new UnauthorizedObjectResult(ApiResponse.Failure("Error while validating token", 401));
            }
        }
    }
}
