using MedicalTestProject.ApiService.Domain.Entities;

namespace MedicalTestProject.ApiService.Application.Repositories;

public interface IDiseaseReadRepository
{
    Task<Disease[]> GetDiseasesAsync(CancellationToken cancellationToken);
}
