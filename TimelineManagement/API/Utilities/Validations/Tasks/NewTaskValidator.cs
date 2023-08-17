﻿using FluentValidation;
using TimelineManagement.DTOs.Tasks;

namespace TimelineManagement.Utilities.Validations.Tasks;

public class NewTaskValidator : AbstractValidator<NewTaskDto>
{
    public NewTaskValidator()
    {
        RuleFor(t => t.Name)
            .NotEmpty().WithMessage("Name is required");
        
        RuleFor(t => t.StartDate)
            .NotEmpty().WithMessage("Start Date is required");
        
        RuleFor(t => t.EndDate)
            .NotEmpty().WithMessage("End Date is required");
        
        RuleFor(t => t.Status)
            .NotEmpty().WithMessage("Status is required");
        
        RuleFor(t => t.Priority)
            .NotNull()
            .IsInEnum();
        
        RuleFor(t => t.ProjectGuid)
            .NotEmpty().WithMessage("Project Guid is required");
        
        RuleFor(t => t.SectionGuid)
            .NotEmpty().WithMessage("Section Guid is required");
        
        RuleFor(t => t.EmployeeGuid)
            .NotEmpty().WithMessage("Employee Guid is required");
    }
}