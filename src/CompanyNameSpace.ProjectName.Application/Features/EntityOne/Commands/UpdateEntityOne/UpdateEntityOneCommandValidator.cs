using FluentValidation;

namespace CompanyNameSpace.ProjectName.Application.Features.EntityOne.Commands.UpdateEntityOne;

public class UpdateEntityOneCommandValidator : AbstractValidator<UpdateEntityOneCommand>
{
    public UpdateEntityOneCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThan(0);
    }
}