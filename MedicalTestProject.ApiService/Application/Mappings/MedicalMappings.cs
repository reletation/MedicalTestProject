using MedicalTestProject.ApiService.Application.DTO;
using MedicalTestProject.ApiService.Domain.Entities;

namespace MedicalTestProject.ApiService.Application.Mappings;

public static class MedicalMappings
{
    public static PatientDto ToDto(this Patient domain)
    {
        DiseaseDto[] diseases = domain.PatientDiseases
            .Select(x => x.Disease)
            .OfType<Disease>()
            .Select(x => x.ToDto())
            .ToArray();

        PatientDto dto = new(
            FullName: $"{domain.FirstName} {domain.MiddleName} {domain.LastName}",
            BirthDate: domain.BirthDate,
            Diseases: diseases);

        return dto;
    }


    public static DiseaseDto ToDto(this Disease domain)
    {
        DiseaseDto dto = new(domain.Name);

        return dto;
    }

    public static DoctorDto ToDto(this Doctor domain)
    {
        SpecializationDto[] specializations = domain.DoctorSpecializations
            .Select(x => x.Specialization)
            .OfType<Specialization>()
            .Select(x => x.ToDto())
            .ToArray();

        DoctorDto dto = new(
            FullName: $"{domain.FirstName} {domain.MiddleName} {domain.LastName}",
            BirthDate: domain.BirthDate,
            Specializations: specializations);

        return dto;
    }

    public static SpecializationDto ToDto(this Specialization domain)
    {
        SpecializationDto dto = new(domain.Name);

        return dto;
    }

}
