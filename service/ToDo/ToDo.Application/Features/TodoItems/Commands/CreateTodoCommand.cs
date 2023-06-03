using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Common.Services;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.TodoItems.Commands;

public class CreateTodoCommand : IRequest<ToDoItem>
{
    public string? Content { get; set; }
}

public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
{
    public CreateTodoCommandValidator()
    {
        RuleFor(x => x.Content).NotEmpty();
    }
}

public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, ToDoItem>
{
    private readonly ITodoItemRepository _todoItemRepository;
    private readonly IDateTimeService _dateTimeService;

    public CreateTodoCommandHandler(ITodoItemRepository todoItemRepository, IDateTimeService dateTimeService)
    {
        _todoItemRepository = todoItemRepository;
        _dateTimeService = dateTimeService;
    }

    public async Task<ToDoItem> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var todoItem = ToDoItem.CreateTodoItem(request.Content, _dateTimeService.UtcNow);
        var todo = await _todoItemRepository.AddTodo(todoItem);

        return todo;
    }
}
