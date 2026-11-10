namespace MedicalTestProject.ApiService.Application.DTO;

public record DoctorDto(
    string FullName,
    DateTime BirthDate,
    SpecializationDto[] Specializations);
