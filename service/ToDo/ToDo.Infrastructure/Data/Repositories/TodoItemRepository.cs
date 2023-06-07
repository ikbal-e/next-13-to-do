using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Features.TodoItems;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.Data.Repositories;

public class TodoItemRepository : ITodoItemRepository
{
    private readonly ToDoContext _context;

    public TodoItemRepository(ToDoContext context)
    {
        _context = context;
    }

    public async Task<ToDoItem> AddTodo(ToDoItem todoItem)
    {
        _context.Add(todoItem);
        await _context.SaveChangesAsync();
        return todoItem;
    }

    public async Task DeleteTodo(Guid id)
    {
        var item = await _context.ToDoItems.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (item is null)
        {
            return;
        }

        await _context.SaveChangesAsync();
    }

    public async Task<ToDoItem?> GetTodo(Guid id)
    {
        return await _context.ToDoItems.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<ICollection<ToDoItem>> GetTodos()
    {
        return await _context.ToDoItems.ToListAsync();
    }

    public async Task<ToDoItem> UpdateTodo(Guid todoId, string content)
    {
        var item = await _context.ToDoItems.Where(x => x.Id == todoId).FirstOrDefaultAsync();
        item.SetContent(content);
        await _context.SaveChangesAsync();
        return item;
    }
}
