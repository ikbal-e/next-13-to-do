using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.Entities;

public class ToDoItem
{
    public Guid Id { get; private set; }
    public string Content { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }

    private ToDoItem(Guid id, string content, DateTime createdAt)
    {
        Id = id;
        Content = content;
        CreatedAt = createdAt;
    }

    public static ToDoItem CreateTodoItem(string content, DateTime createdAt)
    {
        return new(Guid.NewGuid(), content, createdAt);
    }

    public void SetContent(string content)
    {
        Content = content;
    }
}
