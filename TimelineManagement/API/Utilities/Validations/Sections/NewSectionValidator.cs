using FluentValidation;
using TimelineManagement.DTOs.Sections;

namespace TimelineManagement.Utilities.Validations.Sections;

public class NewSectionValidator : AbstractValidator<NewSectionDto>
{
    public NewSectionValidator()
    {
        RuleFor(s => s.Name)
            .NotEmpty().WithMessage("Name is required");
    }
}