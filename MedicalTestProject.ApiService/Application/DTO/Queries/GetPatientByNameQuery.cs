namespace MedicalTestProject.ApiService.Application.DTO.Queries;

public record GetPatientByNameQuery(
    string FirstName,
    string MiddleName,
    string? LastName);
