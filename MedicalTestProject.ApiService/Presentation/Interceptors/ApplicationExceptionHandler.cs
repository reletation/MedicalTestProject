using MedicalTestProject.ApiService.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTestProject.ApiService.Presentation.Interceptors;

public class ApplicationExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync
       (HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not Application.Exceptions.ApplicationException applicationException)
            return false;

        HttpRequest httpRequest = httpContext.Request;

        (int status, string? title) = applicationException.ErrorType switch
        {
            ApplicationErrorType.NotFound => (StatusCodes.Status404NotFound, "Не найдено"),

            _ => (StatusCodes.Status500InternalServerError, "Неопознанная ошибка")
        };

        ProblemDetails problem = new()
        {
            Title = title,
            Detail = applicationException.Message,
            Status = status,
            Instance = httpRequest.Path
        };

        httpContext.Response.StatusCode = status;

        await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);

        return true;
    }
}
