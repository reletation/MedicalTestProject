namespace MedicalTestProject.ApiService.Application.Exceptions;

public class DoctorNotFoundException : ApplicationException
{
    private DoctorNotFoundException(string message = "Доктор не найден") : base(message) { }
    public override ApplicationErrorType ErrorType => ApplicationErrorType.NotFound;
    public static DoctorNotFoundException Create() => new();
}
