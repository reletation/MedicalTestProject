using MedicalTestProject.ApiService.Application.DTO.Queries;
using MedicalTestProject.ApiService.Application.DTO.Response;

namespace MedicalTestProject.ApiService.Application.Services;

public interface IDoctorService
{
    Task<GetDoctorsResponse> GetDoctorsAsync(CancellationToken cancellationToken);
    Task<GetDoctorResponse> GetDoctorAsyncByNameAsync(GetPersonByNameQuery query, CancellationToken cancellationToken);
    Task<GetDoctorsResponse> GetDoctorsAsyncBySpecializationAsync(GetDoctorBySpecializationQuery query, CancellationToken cancellationToken);
}
