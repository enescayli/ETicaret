using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Infrastructure.Filters;

public class ValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        { 
            var erros =  context.ModelState.Where(x => x.Value != null && x.Value.Errors.Any())
                .ToDictionary(e =>
                    e.Key, e => 
                    e.Value?.Errors.Select(error =>  error.ErrorMessage)).ToArray();

             context.Result = new BadRequestObjectResult(erros);
             return;
        }

        await next();
    }
}