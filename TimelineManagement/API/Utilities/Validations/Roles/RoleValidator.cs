using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TimelineManagement.DTOs.Roles;

namespace TimelineManagement.Utilities.Validations.Roles;

public class RoleValidator : AbstractValidator<RoleDto>
{
    public RoleValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty().WithMessage("Name is required");
    }
}