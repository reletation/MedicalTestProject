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


        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<GetPatientResponse>> GetPatientByName
        ([FromQuery] GetPatientByNameQuery query, CancellationToken cancellationToken)
    {

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<GetPatientResponse>> GetPatientByDisease
        ([FromQuery] GetPatientByDiseaseQuery query, CancellationToken cancellationToken)
    {

        return Ok();
    }
}
