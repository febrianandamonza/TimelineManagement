using FluentValidation;
using TimelineManagement.DTOs.TaskComments;

namespace TimelineManagement.Utilities.Validations.TaskComments;

public class TaskCommentValidator : AbstractValidator<TaskCommentDto>
{
    public TaskCommentValidator()
    {
        RuleFor(tc => tc.Description)
            .NotEmpty().WithMessage("Description is required");
        RuleFor(tc => tc.TaskGuid)
            .NotEmpty().WithMessage("Task Guid is required");
    }
}