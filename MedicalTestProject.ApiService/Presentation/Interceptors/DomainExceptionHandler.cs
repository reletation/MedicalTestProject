using MedicalTestProject.ApiService.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTestProject.ApiService.Presentation.Interceptors;

public class DomainExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync
        (HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not DomainException domainException)
            return false;

        HttpRequest httpRequest = httpContext.Request;

        (int status, string? title) = domainException.ErrorType switch
        {
            DomainErrorType.Validation => (StatusCodes.Status400BadRequest, "Ошибка валидации"),
            DomainErrorType.Conflict => (StatusCodes.Status409Conflict, "Конфликт"),
            DomainErrorType.NotFound => (StatusCodes.Status404NotFound, "Ресурс не найден"),

            _ => (StatusCodes.Status500InternalServerError, "Неопознанная ошибка")
        };

        ProblemDetails problem = new()
        {
            Title = title,
            Detail = domainException.Message,
            Status = status,
            Instance = httpRequest.Path
        };

        httpContext.Response.StatusCode = status;

        await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);

        return true;
    }
}
