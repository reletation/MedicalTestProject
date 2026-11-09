using MedicalTestProject.ApiService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalTestProject.ApiService.Infrastructure.Database;

public class PatientMap(
    string tableName, string schema) : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable(tableName, schema);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .HasColumnName("id");


        builder.Property(x => x.FirstName)
               .HasColumnName("first_name")
               .IsRequired();

        builder.Property(x => x.MiddleName)
               .HasColumnName("middle_name")
               .IsRequired();

        builder.Property(x => x.LastName)
               .HasColumnName("last_name");

        builder.Property(x => x.BirthDate)
               .HasColumnName("birth_date");

        builder.Property(x => x.UpdatedAt)
               .HasColumnName("updated_at");
        
        builder.Property(x => x.CreatedAt)
               .HasColumnName("created_at");
    }
}
