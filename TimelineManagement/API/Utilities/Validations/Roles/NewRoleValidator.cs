using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TimelineManagement.DTOs.Roles;

namespace TimelineManagement.Utilities.Validations.Roles;

public class NewRoleValidator : AbstractValidator<NewRoleDto>
{
    public NewRoleValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty().WithMessage("Name is required");
    }
}