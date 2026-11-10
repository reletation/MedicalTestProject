using MedicalTestProject.ApiService.Application.DTO.Response;

namespace MedicalTestProject.ApiService.Application.Services;

public interface IDiseaseService
{
    Task<GetDiseasesResponse> GetDiseasesAsync(CancellationToken cancellationToken);
}
