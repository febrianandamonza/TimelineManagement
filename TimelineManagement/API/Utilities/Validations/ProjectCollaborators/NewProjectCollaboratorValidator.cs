using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TimelineManagement.DTOs.ProjectCollaborators;

namespace TimelineManagement.Utilities.Validations.ProjectCollaborators;
public class NewProjectCollaboratorValidator : AbstractValidator<NewProjectCollaboratorDto>
{
    public NewProjectCollaboratorValidator()
    {
        RuleFor(pc => pc.EmployeeGuid)
            .NotEmpty().WithMessage("Employee Guid is required");
        RuleFor(pc => pc.ProjectGuid)
            .NotEmpty().WithMessage("Project Guid is required");
    }
}