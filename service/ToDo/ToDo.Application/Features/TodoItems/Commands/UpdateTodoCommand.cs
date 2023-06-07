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

public record UpdateTodoCommand(Guid Id, string? Content) : IRequest<ToDoItem>;

public class UpdateTodoCommandValidator : AbstractValidator<UpdateTodoCommand>
{
    public UpdateTodoCommandValidator()
    {
        RuleFor(x => x.Content).NotEmpty();
    }
}

public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, ToDoItem>
{
    private readonly ITodoItemRepository _todoItemRepository;
    private readonly IDateTimeService _dateTimeService;

    public UpdateTodoCommandHandler(ITodoItemRepository todoItemRepository, IDateTimeService dateTimeService)
    {
        _todoItemRepository = todoItemRepository;
        _dateTimeService = dateTimeService;
    }

    public async Task<ToDoItem> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await _todoItemRepository.GetTodo(request.Id);
        _todoItemRepository.UpdateTodo(todo.Id, request.Content);

        return todo;
    }
}
