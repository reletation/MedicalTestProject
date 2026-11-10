using FluentValidation;

namespace MedicalTestProject.ApiService.Application.DTO.Queries.Validators;

public class GetPersonByNameQueryValidator : AbstractValidator<GetPersonByNameQuery>
{
    public GetPersonByNameQueryValidator()
    {
        RuleFor(x => x)
            .Must(HasName)
            .WithMessage("Запрос должен обязательно содержать следующие поля: Имя, Фамилия");
    }

    private bool HasName(GetPersonByNameQuery query)
    {
        return !string.IsNullOrWhiteSpace(query.FirstName) &&
               !string.IsNullOrWhiteSpace(query.MiddleName);
    }
}
