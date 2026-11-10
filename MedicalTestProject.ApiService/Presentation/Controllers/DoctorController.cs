using MedicalTestProject.ApiService.Application.DTO.Queries;
using MedicalTestProject.ApiService.Application.DTO.Response;
using MedicalTestProject.ApiService.Application.Services;
using MedicalTestProject.ApiService.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTestProject.ApiService.Presentation.Controllers;

[ApiController]
[Route("api/doctors")]
public class DoctorController(
    IDoctorService doctorService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetDoctorsResponse>> GetAllDoctors
        (CancellationToken cancellationToken)
    {
        GetDoctorsResponse response = await doctorService.GetDoctorsAsync(cancellationToken);

        return Ok(response);
    }


    [HttpPost("by-name")]
    public async Task<ActionResult<GetDoctorResponse>> GetDoctorByName
        ([FromBody] GetPersonByNameQuery query, CancellationToken cancellationToken)
    {
        GetDoctorResponse response = await doctorService.GetDoctorAsyncByNameAsync(query, cancellationToken);

        return Ok(response);
    }

    [HttpPost("by-specialization")]
    public async Task<ActionResult<GetDoctorsResponse>> GetDoctorsBySpecialization
        ([FromBody] GetDoctorBySpecializationQuery query, CancellationToken cancellationToken)
    {
        GetDoctorsResponse response = await doctorService.GetDoctorsAsyncBySpecializationAsync(query, cancellationToken);

        return Ok(response);
    }
}
