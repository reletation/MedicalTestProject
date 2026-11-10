namespace MedicalTestProject.ApiService.Application.DTO.Queries;

public record GetPersonByNameQuery(
    string FirstName,
    string MiddleName,
    string? LastName);
