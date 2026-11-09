using MedicalTestProject.ApiService.Domain.Exceptions;
using System.Collections.ObjectModel;

namespace MedicalTestProject.ApiService.Domain.Entities;

public class Specialization
{
    private Specialization() { }
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public DateTime UpdatedAt { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private readonly Collection<DoctorSpecialization> _specializationDoctors = [];
    public IReadOnlyCollection<DoctorSpecialization> SpecializationDoctors => _specializationDoctors.AsReadOnly();


    public Specialization(int id, string name, DateTime createdAt)
    {
        Id = id;
        SetName(name);
        UpdatedAt = createdAt;
        CreatedAt = createdAt;
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw FieldNotEmptyException.Create();

        Name = name;
    }
}
