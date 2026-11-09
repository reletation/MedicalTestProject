using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTestProject.ApiService.Presentation.Interceptors;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync
        (HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        HttpRequest httpRequest = httpContext.Request;

        ProblemDetails problem = new()
        {
            Title = "Internal Server Error",
            Detail = "Неопознанная ошибка сервера",
            Status = StatusCodes.Status500InternalServerError,
            Instance = httpRequest.Path
        };

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);

        return true;
    }
}
