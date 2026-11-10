using MedicalTestProject.ApiService.Application.DTO.Queries;
using MedicalTestProject.ApiService.Application.DTO.Response;

namespace MedicalTestProject.ApiService.Application.Services;

public interface IPatientService
{
    Task<GetPatientResponse> GetPatientAsyncByNameAsync(GetPersonByNameQuery query, CancellationToken cancellationToken);
    Task<GetPatientsResponse> GetPatientsAsync(CancellationToken cancellationToken);
    Task<GetPatientsResponse> GetPatientsAsyncByDiseaseAsync(GetPatientByDiseaseQuery query, CancellationToken cancellationToken);
}
