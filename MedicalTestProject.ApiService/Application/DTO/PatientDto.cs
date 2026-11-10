namespace MedicalTestProject.ApiService.Application.DTO;

public record PatientDto(
    string FullName,
    DateTime BirthDate,
    DiseaseDto[] Diseases);
