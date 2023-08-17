using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TimelineManagement.DTOs.ProjectCollaborators;

namespace TimelineManagement.Utilities.Validations.ProjectCollaborators;
public class ProjectCollaboratorValidator : AbstractValidator<ProjectCollaboratorDto>
{
    public ProjectCollaboratorValidator()
    {
        RuleFor(pc => pc.EmployeeGuid)
            .NotEmpty().WithMessage("Employee Guid is required");
        RuleFor(pc => pc.ProjectGuid)
            .NotEmpty().WithMessage("Project Guid is required");
    }
}