using MedicalTestProject.ApiService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalTestProject.ApiService.Infrastructure.Database;

public class DoctorSpecializationMap(string tableName, string schema) : IEntityTypeConfiguration<DoctorSpecialization>
{
    public void Configure(EntityTypeBuilder<DoctorSpecialization> builder)
    {
        builder.ToTable(tableName, schema);

        builder.HasKey(x => new { x.DoctorId, x.SpecializationId });

        builder.Property(x => x.DoctorId)
               .HasColumnName("doctor_id");

        builder.Property(x => x.SpecializationId)
               .HasColumnName("specialization_id");

        builder.Property(x => x.CreatedAt)
               .HasColumnName("created_at");

        builder.HasOne(x => x.Doctor)
               .WithMany(x => x.DoctorSpecializations)
               .HasForeignKey(x => x.DoctorId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Specialization)
               .WithMany(x => x.SpecializationDoctors)
               .HasForeignKey(x => x.SpecializationId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
