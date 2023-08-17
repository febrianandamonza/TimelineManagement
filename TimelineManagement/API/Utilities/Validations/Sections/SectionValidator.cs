using FluentValidation;
using TimelineManagement.DTOs.Sections;

namespace TimelineManagement.Utilities.Validations.Sections;

public class SectionValidator : AbstractValidator<SectionDto>
{
    public SectionValidator()
    {
        RuleFor(s => s.Name)
            .NotEmpty().WithMessage("Name is required");
    }
}