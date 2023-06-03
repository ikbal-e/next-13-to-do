using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.TodoItems.Queries;

public class GetTodosQuery : IRequest<IEnumerable<ToDoItem>>
{
}

public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, IEnumerable<ToDoItem>>
{
    private readonly ITodoItemRepository _todoItemRepository;

    public GetTodosQueryHandler(ITodoItemRepository todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    public async Task<IEnumerable<ToDoItem>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        var todos = await _todoItemRepository.GetTodos();
        return todos;
    }
}
