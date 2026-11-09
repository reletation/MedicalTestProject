namespace MedicalTestProject.ApiService.Domain.Entities.Base;

public class Person
{
    public string FirstName { get; protected set; } = string.Empty;
    public string MiddleName { get; protected set; } = string.Empty;
    public string? LastName { get; protected set; }

    public DateTime BirthDate { get; protected set; }
}
