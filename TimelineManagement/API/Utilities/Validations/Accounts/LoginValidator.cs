using FluentValidation;
using TimelineManagement.DTOs.Account;

namespace TimelineManagement.Utilities.Validations.Accounts;

public class LoginValidator : AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
        RuleFor(login => login.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(login => login.Password)
            .NotEmpty();
    }
}