using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure; 

namespace clinica_bravo_backend.Filters
{
    public class MyActionFilter : IActionFilter
    {
        private readonly ILogger<MyActionFilter> logger;

        public MyActionFilter(ILogger<MyActionFilter> logger)
        {
            this.logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation("Before executing the action");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation("After executing the action");

            var castResult = context.Result as IStatusCodeActionResult;
            if (castResult == null) {
                return;
            }

            var codeStatus = castResult.StatusCode;
            if (codeStatus == 400) {
                var response = new List<string>();
                var currentResult = context.Result as BadRequestObjectResult;
                if (currentResult.Value is string) {
                    response.Add(currentResult.Value.ToString());
                } else if (currentResult.Value is IEnumerable<IdentityError> errors) {
                    foreach (var error in errors) {
                        response.Add(error.Description);
                    }
                } else {
                    foreach (var key in context.ModelState.Keys) {
                        foreach (var error in context.ModelState[key].Errors) {
                            response.Add($"{key}: {error.ErrorMessage}");
                        }
                    }
                }

                context.Result = new BadRequestObjectResult(response);
            }
        }
    }
}
