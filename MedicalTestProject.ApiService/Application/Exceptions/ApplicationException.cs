namespace MedicalTestProject.ApiService.Application.Exceptions;

public abstract class ApplicationException(string message) : Exception(message)
{
    public abstract ApplicationErrorType ErrorType { get; }
}

public enum ApplicationErrorType
{
    NotFound
}
