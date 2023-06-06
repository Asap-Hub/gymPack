using FluentValidation;
using gym.Application.DTOs.TodoDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Commands.Todo.Validations
{
    public class CreateTodoValidation : AbstractValidator<CreateTodoDto>
    {
        public CreateTodoValidation()
        {
            RuleFor(dto => dto.Title).NotNull().NotEmpty();
            RuleFor(dto => dto.Note).NotNull().NotEmpty();
            RuleFor(dto => dto.StartDate).NotNull();
            RuleFor(dto => dto.EndDate).NotNull();

            RuleFor(dto => dto.StartDate)
                .LessThanOrEqualTo(dto => dto.EndDate)
                .When(dto => dto.StartDate.HasValue && dto.EndDate.HasValue)
                .WithMessage("Start date must be less than or equal to end date.");

            RuleFor(dto => dto.EndDate)
                .GreaterThanOrEqualTo(dto => dto.StartDate)
                .When(dto => dto.StartDate.HasValue && dto.EndDate.HasValue)
                .WithMessage("End date must be greater than or equal to start date.");

        }
    }
}
