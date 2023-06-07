using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.TodoItems.Queries;

public record GetTodoQuery(Guid Id) : IRequest<ToDoItem?>;

public class GetTodoQueryHandler : IRequestHandler<GetTodoQuery, ToDoItem?>
{
    private readonly ITodoItemRepository _todoItemRepository;

    public GetTodoQueryHandler(ITodoItemRepository todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    public async Task<ToDoItem?> Handle(GetTodoQuery request, CancellationToken cancellationToken)
    {
        var todo = await _todoItemRepository.GetTodo(request.Id);
        return todo;
    }
}

