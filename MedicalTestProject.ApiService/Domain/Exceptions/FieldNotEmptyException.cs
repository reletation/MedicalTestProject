namespace MedicalTestProject.ApiService.Domain.Exceptions;

public class FieldNotEmptyException : DomainException
{
    private FieldNotEmptyException(string message = "Значение не может быть пустым") : base(message) { }
    public static FieldNotEmptyException Create() => new();
}
