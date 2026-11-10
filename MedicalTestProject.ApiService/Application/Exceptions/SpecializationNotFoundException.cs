namespace MedicalTestProject.ApiService.Application.Exceptions;

public class SpecializationNotFound : ApplicationException
{
    private SpecializationNotFound(string message = "Специализация не найдена") : base(message) { }
    public override ApplicationErrorType ErrorType => ApplicationErrorType.NotFound;
    public static SpecializationNotFound Create() => new();
}
