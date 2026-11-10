namespace MedicalTestProject.ApiService.Domain.Exceptions;

public abstract class DomainException(string message) : Exception(message)
{
    public abstract DomainErrorType ErrorType { get; }
}

public enum DomainErrorType
{
    Validation,
    Conflict,
    NotFound
}
