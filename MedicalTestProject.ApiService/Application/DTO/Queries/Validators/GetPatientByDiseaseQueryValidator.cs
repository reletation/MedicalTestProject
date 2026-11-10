using FluentValidation;

namespace MedicalTestProject.ApiService.Application.DTO.Queries.Validators;

public class GetPatientByDiseaseQueryValidator : AbstractValidator<GetPatientByDiseaseQuery>
{
    public GetPatientByDiseaseQueryValidator()
    {
        RuleFor(x => x.DiseaseName)
            .NotEmpty()
            .WithMessage("Запрос должен содержать название болезни");

    }
}
