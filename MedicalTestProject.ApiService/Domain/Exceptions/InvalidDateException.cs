namespace MedicalTestProject.ApiService.Domain.Exceptions;

public class InvalidDateException : DomainException
{
    private InvalidDateException(string message = "Значение не может быть пустым") : base(message) { }

    public static InvalidDateException Create() => new();
}
