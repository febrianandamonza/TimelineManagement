using FluentValidation;
using TimelineManagement.DTOs.Projects;

namespace TimelineManagement.Utilities.Validations.Projects;

public class ProjectValidator : AbstractValidator<ProjectDto>
{
    public ProjectValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Name is required");
        RuleFor(p => p.StartDate)
            .NotEmpty().WithMessage("Start Date is required");
        RuleFor(p => p.EndDate)
            .NotEmpty().WithMessage("End Date is required");
        RuleFor(p => p.EmployeeGuid)
            .NotEmpty().WithMessage("Employee Guid is required");
    }
}