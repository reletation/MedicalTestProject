using MedicalTestProject.ApiService.Application.Repositories;
using MedicalTestProject.ApiService.Domain.Entities;
using MedicalTestProject.ApiService.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace MedicalTestProject.ApiService.Infrastructure.Repositories;

public class DoctorReadRepository(
    MedicalContext medicalContext) : IDoctorReadRepository
{
    public async Task<Doctor[]> GetDoctorsAsync(CancellationToken cancellationToken)
    {
        Doctor[] doctors = await medicalContext.Doctors.AsNoTracking()
            .Include(x => x.DoctorSpecializations)
                .ThenInclude(x => x.Specialization)
            .ToArrayAsync(cancellationToken);

        return doctors;
    }

    public async Task<Doctor?> GetDoctorByNameAsync
        (string firstName, string middleName, string? lastName, CancellationToken cancellationToken)
    {
        Doctor? doctor = await medicalContext.Doctors.AsNoTracking()
           .Include(x => x.DoctorSpecializations)
               .ThenInclude(x => x.Specialization)
           .Where(x => x.FirstName == firstName)
           .Where(x => x.MiddleName == middleName)
           .Where(x => x.LastName == lastName)
           .FirstOrDefaultAsync(cancellationToken);

        return doctor;
    }

    public async Task<Doctor[]?> GetDoctorsBySpecializationAsync
        (string specializationName, CancellationToken cancellationToken)
    {
        Specialization? specialization = await medicalContext.Specializations.AsNoTracking()
            .Include(x => x.SpecializationDoctors)
                .ThenInclude(x => x.Doctor)
            .Where(x => x.Name == specializationName)
            .FirstOrDefaultAsync(cancellationToken);

        if (specialization == null)
            return null;

        if (specialization.SpecializationDoctors.Count == 0)
            return [];

        return specialization.SpecializationDoctors
            .Select(x => x.Doctor)
            .OfType<Doctor>()
            .ToArray();
    }
}
