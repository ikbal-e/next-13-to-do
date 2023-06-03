using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Features.TodoItems.Commands;
using ToDo.Application.Features.TodoItems.Queries;

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
