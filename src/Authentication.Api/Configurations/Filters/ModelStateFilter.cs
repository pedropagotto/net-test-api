using System.Net;
using System.Net.Mime;
using System.Text.Json;
using Authentication.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Authentication.Api.Configurations.Filters;

public class ModelStateFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.ModelState.IsValid)
            await next();

        var messages = context.ModelState.Values
            .Where(x => x.Errors.Count > 0)
            .SelectMany(x => x.Errors)
            .Select(x => new ErrorMessage(x.ErrorMessage))
            .ToList();
        var response = new
        {
            Errors = messages
        };

        context.Result = new ContentResult
        {
            Content = JsonSerializer.Serialize(response),
            StatusCode = (int) HttpStatusCode.BadRequest,
            ContentType = MediaTypeNames.Application.Json
        };
    }
}
