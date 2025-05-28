using Core.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Attribute
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var arg in context.ActionArguments)
            {
                var argName = arg.Key;
                var argValue = arg.Value;

                Console.WriteLine($"Argument '{argName}': {JsonConvert.SerializeObject(argValue)}");
            }

            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.ToDictionary(
                kvp => char.ToLowerInvariant(kvp.Key[0]) + kvp.Key.Substring(1),
                kvp => string.Join("; ", kvp.Value.Errors.Select(e => e.ErrorMessage))
            );

                var response = ApiResponse.Failure("Validate error", 400, errors);

                context.Result = new BadRequestObjectResult(response);
            }
        }
    }
}
