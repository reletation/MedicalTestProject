using MedicalTestProject.ApiService.Application.Repositories;
using MedicalTestProject.ApiService.Domain.Entities;
using MedicalTestProject.ApiService.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace MedicalTestProject.ApiService.Infrastructure.Repositories;

public class DiseaseReadRepository(
    MedicalContext medicalContext) : IDiseaseReadRepository
{
    public async Task<Disease[]> GetDiseasesAsync
        (CancellationToken cancellationToken)
    {
        Disease[] diseases = await medicalContext.Diseases.AsNoTracking()
            .ToArrayAsync(cancellationToken);

        return diseases; 
    }
}
