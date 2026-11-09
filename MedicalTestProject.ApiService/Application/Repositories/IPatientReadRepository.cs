using MedicalTestProject.ApiService.Domain.Entities;

namespace MedicalTestProject.ApiService.Application.Repositories;

public interface IPatientReadRepository
{
    Task<Patient?> GetPatientByName(string firstName, string middleName, string? lastName, CancellationToken cancellationToken);
    Task<Patient[]> GetPatientsAsync(CancellationToken cancellationToken);
}
