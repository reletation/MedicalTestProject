using MedicalTestProject.ApiService.Application.DTO.Queries;
using MedicalTestProject.ApiService.Application.DTO.Response;
using MedicalTestProject.ApiService.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTestProject.ApiService.Presentation.Controllers;

[ApiController]
[Route("api/patients")]
public class PatientController(
    IPatientService patientService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetPatientsResponse>> GetAllPatients
        (CancellationToken cancellationToken)
    {
        GetPatientsResponse response = await patientService.GetPatientsAsync(cancellationToken);

        return Ok(response);
    }

    [HttpPost("by-name")]
    public async Task<ActionResult<GetPatientResponse>> GetPatientByName
        ([FromBody] GetPersonByNameQuery query, CancellationToken cancellationToken)
    {
        GetPatientResponse response = await patientService.GetPatientAsyncByNameAsync(query, cancellationToken);

        return Ok(response);
    }

    [HttpPost("by-disease")]
    public async Task<ActionResult<GetPatientResponse>> GetPatientsByDisease
        ([FromBody] GetPatientByDiseaseQuery query, CancellationToken cancellationToken)
    {
        GetPatientsResponse response = await patientService.GetPatientsAsyncByDiseaseAsync(query, cancellationToken);

        return Ok(response);
    }
}
