using FluentValidation;
using TimelineManagement.DTOs.Projects;

namespace TimelineManagement.Utilities.Validations.Projects;

public class NewProjectValidator : AbstractValidator<NewProjectDto>
{
    public NewProjectValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Name is required");
        RuleFor(p => p.StartDate)
            .NotEmpty().WithMessage("Start Date is required");
        RuleFor(p => p.EndDate)
            .NotEmpty().WithMessage("End Date is required").GreaterThanOrEqualTo(p => p.StartDate).WithMessage("Date To must be after Date From");
        RuleFor(p => p.EmployeeGuid)
            .NotEmpty().WithMessage("Employee Guid is required");
    }
}