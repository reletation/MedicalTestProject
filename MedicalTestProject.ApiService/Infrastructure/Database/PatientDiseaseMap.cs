using MedicalTestProject.ApiService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalTestProject.ApiService.Infrastructure.Database;

public class PatientDiseaseMap(string tableName, string schema) : IEntityTypeConfiguration<PatientDisease>
{
    public void Configure(EntityTypeBuilder<PatientDisease> builder)
    {
        builder.ToTable(tableName, schema);

        builder.HasKey(x => new { x.PatientId, x.DiseaseId });

        builder.Property(x => x.PatientId)
               .HasColumnName("patient_id");

        builder.Property(x => x.DiseaseId)
               .HasColumnName("disease_id");

        builder.Property(x => x.CreatedAt)
               .HasColumnName("created_at");

        builder.HasOne(x => x.Patient)
               .WithMany(x => x.PatientDiseases)
               .HasForeignKey(x => x.PatientId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Disease)
               .WithMany(x => x.DiseasePatients)
               .HasForeignKey(x => x.DiseaseId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
