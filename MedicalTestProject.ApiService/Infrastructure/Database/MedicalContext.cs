using MedicalTestProject.ApiService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalTestProject.ApiService.Infrastructure.Database;

public class MedicalContext(DbContextOptions<MedicalContext> options) : DbContext(options)
{
    private const string schema = "medical";

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Disease> Diseases { get; set; }
    public DbSet<Specialization> Specializations { get; set; }
    public DbSet<PatientDisease> PatientsDiseases { get; set; }
    public DbSet<DoctorSpecialization> DoctorsSpecializations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PatientMap("patients", schema))
                    .ApplyConfiguration(new DoctorMap("doctors", schema))
                    .ApplyConfiguration(new DiseaseMap("diseases", schema))
                    .ApplyConfiguration(new SpecializationMap("specializations", schema))
                    .ApplyConfiguration(new PatientDiseaseMap("patients_diseases", schema))
                    .ApplyConfiguration(new DoctorSpecializationMap("doctors_specializations", schema));
    }
}
