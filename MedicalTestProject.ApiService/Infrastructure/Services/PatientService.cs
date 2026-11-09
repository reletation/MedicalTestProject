using MedicalTestProject.ApiService.Application.DTO.Response;
using MedicalTestProject.ApiService.Application.Repositories;
using MedicalTestProject.ApiService.Application.Services;
using MedicalTestProject.ApiService.Domain.Entities;

namespace MedicalTestProject.ApiService.Infrastructure.Services;

public class PatientService(
    IPatientReadRepository patientReadRepository) : IPatientService
{
    public async Task<GetPatientsResponse> GetPatients
        (CancellationToken cancellationToken)
    {
        Patient[] patients = await patientReadRepository.GetPatientsAsync(cancellationToken);

        GetPatientsResponse response = new(
            Patients: patients.Select(x=> x.To);

    }

}
