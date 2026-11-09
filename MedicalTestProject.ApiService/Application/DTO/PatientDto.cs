using MedicalTestProject.ApiService.Domain.Entities;

namespace MedicalTestProject.ApiService.Application.DTO;

public record PatientDto(
    string FullName,
    DateTime BirthDate,
    Disease[] Diseases);
