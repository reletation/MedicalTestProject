using FluentValidation;

namespace MedicalTestProject.ApiService.Application.DTO.Queries.Validators;

public class GetDoctorBySpecializationQueryValidator : AbstractValidator<GetDoctorBySpecializationQuery>
{
    public GetDoctorBySpecializationQueryValidator()
    {
        RuleFor(x => x.SpecializationName)
            .NotEmpty()
            .WithMessage("Запрос должен содержать название специализации");
    }
}
