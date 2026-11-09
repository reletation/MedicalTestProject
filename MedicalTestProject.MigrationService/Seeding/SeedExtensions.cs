using MedicalTestProject.ApiService.Domain.Entities;
using MedicalTestProject.ApiService.Infrastructure.Database;
using MedicalTestProject.MigrationService.Seeding.Data;
using Microsoft.EntityFrameworkCore;

namespace MedicalTestProject.MigrationService.Seeding;

public static class SeedExtensions
{
    public static void SeedData
        (this MedicalContext medicalContext)
    {
        DateTime now = DateTime.UtcNow;

        medicalContext.SeedDiseases(now)
                      .SeedDoctors(now)
                      .SeedPatients(now)
                      .SeedSpecializations(now);

        medicalContext.SaveChanges();

        Dictionary<int, Disease> diseases = medicalContext.Diseases
            .ToDictionary(x => x.Id);

        Dictionary<int, Doctor> doctors = medicalContext.Doctors
            .ToDictionary(x => x.Id);

        Dictionary<int, Patient> patients = medicalContext.Patients
            .ToDictionary(x => x.Id);

        Dictionary<int, Specialization> specializations = medicalContext.Specializations
            .ToDictionary(x => x.Id);


        medicalContext.SeedDoctorSpecializations(doctors, specializations, now)
                      .SeedPatientDiseases(patients, diseases, now);

        medicalContext.SaveChanges();
    }

    public static async Task SeedDataAsync
        (this MedicalContext medicalContext, CancellationToken cancellationToken)
    {
        DateTime now = DateTime.UtcNow;

        medicalContext.SeedDiseases(now)
                      .SeedDoctors(now)
                      .SeedPatients(now)
                      .SeedSpecializations(now);

        await medicalContext.SaveChangesAsync(cancellationToken);

        Dictionary<int, Disease> diseases = await medicalContext.Diseases
           .ToDictionaryAsync(x => x.Id, cancellationToken);

        Dictionary<int, Doctor> doctors = await medicalContext.Doctors
            .ToDictionaryAsync(x => x.Id, cancellationToken);

        Dictionary<int, Patient> patients = await medicalContext.Patients
            .ToDictionaryAsync(x => x.Id, cancellationToken);

        Dictionary<int, Specialization> specializations = await medicalContext.Specializations
            .ToDictionaryAsync(x => x.Id, cancellationToken);


        medicalContext.SeedDoctorSpecializations(doctors, specializations, now)
                      .SeedPatientDiseases(patients, diseases, now);

        await medicalContext.SaveChangesAsync(cancellationToken);
    }

    private static MedicalContext SeedDiseases
        (this MedicalContext medicalContext, DateTime createdAt)
    {
        if (medicalContext.Diseases.Any())
            return medicalContext;

        Disease[] diseases = DiseaseSeedData.GetDiseases(createdAt);

        medicalContext.Diseases.AddRange(diseases);

        return medicalContext;
    }

    private static MedicalContext SeedSpecializations
        (this MedicalContext medicalContext, DateTime createdAt)
    {
        if (medicalContext.Specializations.Any())
            return medicalContext;

        Specialization[] specializations = SpecializationSeedData.GetSpecializations(createdAt);

        medicalContext.Specializations.AddRange(specializations);
        return medicalContext;
    }

    private static MedicalContext SeedDoctors
        (this MedicalContext medicalContext, DateTime createdAt)
    {
        if (medicalContext.Doctors.Any())
            return medicalContext;

        Doctor[] doctors = DoctorSeedData.GetDoctors(createdAt);

        medicalContext.Doctors.AddRange(doctors);
        return medicalContext;
    }

    private static MedicalContext SeedPatients
        (this MedicalContext medicalContext, DateTime createdAt)
    {
        if (medicalContext.Patients.Any())
            return medicalContext;

        Patient[] patients = PatientSeedData.GetPatients(createdAt);

        medicalContext.Patients.AddRange(patients);
        return medicalContext;
    }

    private static MedicalContext SeedDoctorSpecializations(
        this MedicalContext medicalContext,
        Dictionary<int, Doctor> doctors,
        Dictionary<int, Specialization> specializations,
        DateTime createdAt)
    {
        if (medicalContext.DoctorsSpecializations.Any())
            return medicalContext;

        DoctorSpecialization[] doctorSpecializations = DoctorSpecializationSeedData.GetDoctorSpecializations(doctors, specializations, createdAt);

        medicalContext.DoctorsSpecializations.AddRange(doctorSpecializations);

        return medicalContext;
    }


    private static MedicalContext SeedPatientDiseases(
        this MedicalContext medicalContext,
        Dictionary<int, Patient> patients,
        Dictionary<int, Disease> diseases,
        DateTime createdAt)
    {
        if (medicalContext.PatientsDiseases.Any())
            return medicalContext;

        PatientDisease[] patientDiseases = PatientDiseaseSeedData.GetPatientDiseases(patients, diseases, createdAt);

        medicalContext.PatientsDiseases.AddRange(patientDiseases);

        return medicalContext;
    }
}
