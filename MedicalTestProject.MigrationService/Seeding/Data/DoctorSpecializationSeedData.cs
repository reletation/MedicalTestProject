using MedicalTestProject.ApiService.Domain.Entities;

namespace MedicalTestProject.MigrationService.Seeding.Data;

public static class DoctorSpecializationSeedData
{
    public static DoctorSpecialization[] GetDoctorSpecializations
        (Dictionary<int, Doctor> doctor, Dictionary<int, Specialization> spec, DateTime createdAt)
    {
        return
        [
            new (doctor[1],  spec[1], createdAt),
            new (doctor[1],  spec[3], createdAt),
            new (doctor[2],  spec[2], createdAt),
            new (doctor[2],  spec[5], createdAt),
            new (doctor[3],  spec[1], createdAt),
            new (doctor[3],  spec[4], createdAt),
            new (doctor[4],  spec[3], createdAt),
            new (doctor[4],  spec[9], createdAt),
            new (doctor[5],  spec[2], createdAt),
            new (doctor[5],  spec[10], createdAt),
            new (doctor[6],  spec[5], createdAt),
            new (doctor[6],  spec[6], createdAt),
            new (doctor[7],  spec[4], createdAt),
            new (doctor[7],  spec[8], createdAt),
            new (doctor[8],  spec[7], createdAt),
            new (doctor[8],  spec[9], createdAt),
            new (doctor[9],  spec[1], createdAt),
            new (doctor[9],  spec[2], createdAt),
            new (doctor[10], spec[3], createdAt),
            new (doctor[10], spec[10], createdAt)
        ];
    }
}
