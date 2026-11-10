namespace MedicalTestProject.ApiService.Application.Exceptions;

public class PatientNotFoundException: ApplicationException
{
    private PatientNotFoundException(string message = "Пациент не найден") : base(message) { }
    public override ApplicationErrorType ErrorType => ApplicationErrorType.NotFound;
    public static PatientNotFoundException Create() => new();
}
