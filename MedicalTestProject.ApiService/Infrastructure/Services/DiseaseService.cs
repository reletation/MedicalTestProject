using MedicalTestProject.ApiService.Application.DTO;
using MedicalTestProject.ApiService.Application.DTO.Response;
using MedicalTestProject.ApiService.Application.Mappings;
using MedicalTestProject.ApiService.Application.Repositories;
using MedicalTestProject.ApiService.Application.Services;
using MedicalTestProject.ApiService.Domain.Entities;

namespace MedicalTestProject.ApiService.Infrastructure.Services;

public class DiseaseService(
    IDiseaseReadRepository diseaseReadRepository) : IDiseaseService
{
    public async Task<GetDiseasesResponse> GetDiseasesAsync
        (CancellationToken cancellationToken)
    {
        Disease[] diseases = await diseaseReadRepository.GetDiseasesAsync(cancellationToken);

        DiseaseDto[] diseaseDtos = diseases.Select(x => x.ToDto())
            .ToArray();

        GetDiseasesResponse response = new(
            Diseases: diseaseDtos);

        return response;
    }
}
