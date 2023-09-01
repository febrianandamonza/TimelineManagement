using FluentValidation;
using TimelineManagement.DTOs.Tasks;

namespace TimelineManagement.Utilities.Validations.Tasks;

public class NewDefaultTaskValidator : AbstractValidator<NewDefaultTaskDto>
{
    public NewDefaultTaskValidator()
    {
        RuleFor(t => t.Name)
            .NotEmpty().WithMessage("Name is required");
        
        RuleFor(t => t.StartDate)
            .NotEmpty().WithMessage("Start Date is required");

        RuleFor(t => t.EndDate)
            .NotEmpty().WithMessage("End Date is required")
            .GreaterThanOrEqualTo(p => p.StartDate).WithMessage("Date To must be after or equal Start Date From");

        RuleFor(t => t.Priority)
            .NotNull()
            .IsInEnum();
        
        RuleFor(t => t.ProjectGuid)
            .NotEmpty().WithMessage("Project Guid is required");

        RuleFor(t => t.EmployeeEmail)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is mot valid");

    }
}