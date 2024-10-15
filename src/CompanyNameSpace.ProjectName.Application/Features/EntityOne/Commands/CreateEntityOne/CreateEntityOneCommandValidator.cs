using FluentValidation;

namespace CompanyNameSpace.ProjectName.Application.Features.EntityOne.Commands.CreateEntityOne
{
    public class CreateEntityOneCommandValidator : AbstractValidator<CreateEntityOneCommand>
    {
        public CreateEntityOneCommandValidator()
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
}
