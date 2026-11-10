using MedicalTestProject.ApiService.Application.DTO.Response;
using MedicalTestProject.ApiService.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTestProject.ApiService.Presentation.Controllers;

[ApiController]
[Route("api/diseases")]
public class DiseaseController(
    IDiseaseService diseaseService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetDiseasesResponse>> GetDiseases
        (CancellationToken cancellationToken)
    {
        GetDiseasesResponse response = await diseaseService.GetDiseasesAsync(cancellationToken);

        return Ok(response);
    }
}
