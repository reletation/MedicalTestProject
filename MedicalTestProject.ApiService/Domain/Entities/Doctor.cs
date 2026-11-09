using MedicalTestProject.ApiService.Domain.Entities.Base;
using MedicalTestProject.ApiService.Domain.Exceptions;
using System.Collections.ObjectModel;

namespace MedicalTestProject.ApiService.Domain.Entities;

public class Doctor : Person
{
    private Doctor() { }
    public int Id { get; private set; }

    public DateTime UpdatedAt { get; private set; }
    public DateTime CreatedAt { get; private set; }


    private readonly Collection<DoctorSpecialization> _doctorSpecializations = [];
    public IReadOnlyCollection<DoctorSpecialization> DoctorSpecializations => _doctorSpecializations.AsReadOnly();


    public Doctor(
        int id, 
        string firstName, 
        string middleName, 
        string lastName,
        DateTime birthDate,
        DateTime createdAt)
    {
        Id = id;
        SetFirstName(firstName);
        SetMiddleName(middleName);
        SetLastName(lastName);
        SetBirthDate(birthDate);

        UpdatedAt = createdAt;
        CreatedAt = createdAt;
    }

    public void SetFirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw FieldNotEmptyException.Create();

        FirstName = firstName;
    }

    public void SetMiddleName(string middleName)
    {
        if (string.IsNullOrWhiteSpace(middleName))
            throw FieldNotEmptyException.Create();


        MiddleName = middleName;
    }

    public void SetLastName(string lastName)
    {
        LastName = lastName;
    }

    public void SetBirthDate(DateTime date)
    {
        if (date <= new DateTime(1926, 1, 1))
            throw InvalidDateException.Create();

        BirthDate = date;
    }
}
