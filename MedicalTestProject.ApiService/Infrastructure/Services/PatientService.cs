using MedicalTestProject.ApiService.Application.DTO;
using MedicalTestProject.ApiService.Application.DTO.Queries;
using MedicalTestProject.ApiService.Application.DTO.Response;
using MedicalTestProject.ApiService.Application.Exceptions;
using MedicalTestProject.ApiService.Application.Mappings;
using MedicalTestProject.ApiService.Application.Repositories;
using MedicalTestProject.ApiService.Application.Services;
using MedicalTestProject.ApiService.Domain.Entities;

namespace MedicalTestProject.ApiService.Infrastructure.Services;

public class PatientService(
    IPatientReadRepository patientReadRepository) : IPatientService
{
    public async Task<GetPatientsResponse> GetPatientsAsync
        (CancellationToken cancellationToken)
    {
        Patient[] patients = await patientReadRepository.GetPatientsAsync(cancellationToken);

        GetPatientsResponse response = new(
            Patients: patients.Select(x => x.ToDto()).ToArray()
            );

        return response;
    }

    public async Task<GetPatientResponse> GetPatientAsyncByNameAsync
        (GetPersonByNameQuery query, CancellationToken cancellationToken)
    {
        Patient patient = await patientReadRepository.GetPatientByName(query.FirstName, query.MiddleName, query.LastName, cancellationToken)
            ?? throw PatientNotFoundException.Create();

        GetPatientResponse response = new(
            Patient: patient.ToDto());

        return response;
    }

    public async Task<GetPatientsResponse> GetPatientsAsyncByDiseaseAsync
        (GetPatientByDiseaseQuery query ,CancellationToken cancellationToken)
    {
        Patient[] patients = await patientReadRepository.GetPatentsByDiseaseAsync(query.DiseaseName, cancellationToken);

        PatientDto[] patientDtos = patients.Select(x => x.ToDto())
            .ToArray();

        GetPatientsResponse response = new(Patients: patientDtos);

        return response;                
    }
}
