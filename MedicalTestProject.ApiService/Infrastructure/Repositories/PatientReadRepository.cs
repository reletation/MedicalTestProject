using MedicalTestProject.ApiService.Application.Repositories;
using MedicalTestProject.ApiService.Domain.Entities;
using MedicalTestProject.ApiService.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace MedicalTestProject.ApiService.Infrastructure.Repositories;

public class PatientReadRepository(
    MedicalContext medicalContext) : IPatientReadRepository
{
    public async Task<Patient[]> GetPatientsAsync
        (CancellationToken cancellationToken)
    {
        Patient[] patients = await medicalContext.Patients.AsNoTracking()
            .Include(x => x.PatientDiseases)
                .ThenInclude(x => x.Disease)
            .ToArrayAsync(cancellationToken);
        
        return patients;
    }

    public async Task<Patient?> GetPatientByName
        (string firstName, string middleName, string? lastName, CancellationToken cancellationToken)
    {
        Patient? patient = await medicalContext.Patients.AsNoTracking()
            .Include(x=>x.PatientDiseases)
                .ThenInclude(x=> x.Disease)
            .Where(x => x.FirstName == firstName)
            .Where(x => x.MiddleName == middleName)
            .Where(x => x.LastName == lastName)
            .FirstOrDefaultAsync(cancellationToken);

        return patient;
    }

    public async Task<Patient[]> GetPatentsByDiseaseAsync
        (string diseaseName, CancellationToken cancellationToken)
    {
        Disease? disease = await medicalContext.Diseases.AsNoTracking()
            .Include(x=>x.DiseasePatients)
                .ThenInclude(x=>x.Patient)
            .Where(x => x.Name == diseaseName)
            .FirstOrDefaultAsync(cancellationToken);

        if (disease == null)
            return [];

        if (disease.DiseasePatients.Count == 0)
            return [];

        return disease.DiseasePatients
            .Select(x => x.Patient)
            .OfType<Patient>()
            .ToArray();
    }
}
