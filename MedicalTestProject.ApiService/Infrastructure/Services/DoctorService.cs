using MedicalTestProject.ApiService.Application.DTO;
using MedicalTestProject.ApiService.Application.DTO.Queries;
using MedicalTestProject.ApiService.Application.DTO.Response;
using MedicalTestProject.ApiService.Application.Exceptions;
using MedicalTestProject.ApiService.Application.Mappings;
using MedicalTestProject.ApiService.Application.Repositories;
using MedicalTestProject.ApiService.Application.Services;
using MedicalTestProject.ApiService.Domain.Entities;

namespace MedicalTestProject.ApiService.Infrastructure.Services;

public class DoctorService(
    IDoctorReadRepository doctorReadRepository) : IDoctorService
{
    public async Task<GetDoctorsResponse> GetDoctorsAsync
        (CancellationToken cancellationToken)
    {
        Doctor[] doctors = await doctorReadRepository.GetDoctorsAsync(cancellationToken);

        DoctorDto[] doctorsDtos = doctors.Select(x => x.ToDto()).ToArray();

        GetDoctorsResponse response = new(
            Doctors: doctorsDtos
            );

        return response;
    }

    public async Task<GetDoctorResponse> GetDoctorAsyncByNameAsync
        (GetPersonByNameQuery query, CancellationToken cancellationToken)
    {
        Doctor doctor = await doctorReadRepository.GetDoctorByNameAsync(query.FirstName, query.MiddleName, query.LastName, cancellationToken)
            ?? throw DoctorNotFoundException.Create();

        GetDoctorResponse response = new(
            Doctor: doctor.ToDto());

        return response;
    }

    public async Task<GetDoctorsResponse> GetDoctorsAsyncBySpecializationAsync
        (GetDoctorBySpecializationQuery query, CancellationToken cancellationToken)
    {
        Doctor[]? doctors = await doctorReadRepository.GetDoctorsBySpecializationAsync(query.SpecializationName, cancellationToken)
            ?? throw SpecializationNotFound.Create();

        DoctorDto[] doctorDtos = doctors.Select(x => x.ToDto())
            .ToArray();

        GetDoctorsResponse response = new(Doctors: doctorDtos);

        return response;
    }

}
