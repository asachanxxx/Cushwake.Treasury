using FluentValidation;

namespace Cushwake.Treasury.Application.TodoItems.Commands.CreateTodoItem;

public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
{
    public CreateTodoItemCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(10)
            .NotEmpty();
    }
}

