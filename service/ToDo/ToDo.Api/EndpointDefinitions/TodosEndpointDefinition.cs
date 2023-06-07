using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Features.TodoItems.Commands;
using ToDo.Application.Features.TodoItems.Queries;
using ToDo.Domain.Entities;

namespace ToDo.Api.EndpointDefinitions;

public class TodosEndpointDefinition : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var todos = app.MapGroup("/api/todos");

        todos.MapGet("/", async (IMediator mediator) =>
        {
            var todos = await mediator.Send(new GetTodosQuery());

            return TypedResults.Ok(todos);
        })
        .WithName("GetTodos")
        .WithOpenApi();

        todos.MapGet("/{id}", async Task<Results<Ok<ToDoItem>, NotFound>> (IMediator mediator, [FromRoute] Guid id) =>
        {
            var todo = await mediator.Send(new GetTodoQuery(id));

            return todo is null
                    ? TypedResults.NotFound()
                    : TypedResults.Ok(todo);
        })
       .WithName("GetTodo")
       .WithOpenApi();

        todos.MapPost("/", async (IMediator mediator, [FromBody] CreateTodoCommand createTodoCommand) =>
        {
            var todo = await mediator.Send(new CreateTodoCommand
            {
                Content = createTodoCommand.Content
            });

            return TypedResults.Ok(todo);
        })
        .WithName("AddTodo")
        .WithOpenApi();
    }
}
