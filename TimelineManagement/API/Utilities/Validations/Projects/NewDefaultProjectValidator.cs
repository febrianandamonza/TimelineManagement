using FluentValidation;
using TimelineManagement.DTOs.Projects;

namespace TimelineManagement.Utilities.Validations.Projects;

public class NewDefaultProjectValidator : AbstractValidator<NewDefaultProjectDto>
{
    public NewDefaultProjectValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Name is required");
        RuleFor(p => p.StartDate)
            .NotEmpty().WithMessage("Start Date is required");
        RuleFor(p => p.EndDate)
            .NotEmpty().WithMessage("End Date is required").GreaterThanOrEqualTo(p => p.StartDate).WithMessage("Date To must be after or equel Start Date From");
        RuleFor(p => p.EmployeeGuid)
            .NotEmpty().WithMessage("Employee Guid is required");
        RuleFor(p => p.TaskName)
            .NotEmpty().WithMessage("Task Name is required");
        RuleFor(p => p.TaskName)
            .NotEmpty().WithMessage("Task Name is required");
        RuleFor(p => p.Priority)
            .NotNull()
            .IsInEnum();
        RuleFor(p => p.StartDateTask)
            .NotEmpty().WithMessage("Start Date Task is required");
        RuleFor(p => p.EndDateTask)
            .NotEmpty().WithMessage("End Date Task is required").GreaterThanOrEqualTo(p => p.StartDateTask).WithMessage("Date To must be after or equal Start Date From");
    }
    
}