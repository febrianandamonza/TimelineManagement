using FluentValidation;
using TimelineManagement.DTOs.AccountRoles;

namespace TimelineManagement.Utilities.Validations.AccountRoles;

public class AccountRoleValidator : AbstractValidator<AccountRoleDto>
{
    public AccountRoleValidator()
    {
        RuleFor(ar => ar.AccountGuid)
            .NotEmpty().WithMessage("Account Guid is required");
        RuleFor(ar => ar.RoleGuid)
            .NotEmpty().WithMessage("Employee Guid is required");
    }
}