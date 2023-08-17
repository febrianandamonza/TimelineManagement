using FluentValidation;
using TimelineManagement.DTOs.TaskComments;

namespace TimelineManagement.Utilities.Validations.TaskComments;

public class NewTaskCommentValidator : AbstractValidator<NewTaskCommentDto>
{
    public NewTaskCommentValidator()
    {
        RuleFor(tc => tc.Description)
            .NotEmpty().WithMessage("Description is required");
        RuleFor(tc => tc.TaskGuid)
            .NotEmpty().WithMessage("Task Guid is required");
    }
}