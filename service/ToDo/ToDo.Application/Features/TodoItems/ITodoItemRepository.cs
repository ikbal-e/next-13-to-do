using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.TodoItems;

public interface ITodoItemRepository
{
    Task<ICollection<ToDoItem>> GetTodos();
    Task<ToDoItem> GetTodo(Guid id);
    Task<ToDoItem> AddTodo(ToDoItem todoItem);
    Task<ToDoItem> UpdateTodo(Guid todoId, string content);
    Task DeleteTodo(Guid id);

}
