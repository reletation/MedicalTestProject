namespace MedicalTestProject.ApiService.Domain.Exceptions;

public class InvalidDateException : DomainException
{
    private InvalidDateException(string message = "Значение не может быть пустым") : base(message) { }
    public override DomainErrorType ErrorType => DomainErrorType.Validation;
    public static InvalidDateException Create() => new();
}
