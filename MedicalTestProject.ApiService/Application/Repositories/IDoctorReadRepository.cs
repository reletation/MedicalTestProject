using MedicalTestProject.ApiService.Domain.Entities;

namespace MedicalTestProject.ApiService.Application.Repositories;

public interface IDoctorReadRepository
{
    Task<Doctor?> GetDoctorByNameAsync(string firstName, string middleName, string? lastName, CancellationToken cancellationToken);
    Task<Doctor[]> GetDoctorsAsync(CancellationToken cancellationToken);
    Task<Doctor[]> GetDoctorsBySpecializationAsync(string specializationName, CancellationToken cancellationToken);
}
