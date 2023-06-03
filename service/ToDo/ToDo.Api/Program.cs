using ToDo.Infrastructure;
using ToDo.Application;
using MediatR;
using ToDo.Application.Features.TodoItems.Commands;
using ToDo.Application.Features.TodoItems.Queries;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddInftrastructure()
        .AddApplication();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}


var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapGet("/todos", async (IMediator mediator) =>
    {
        var todos = await mediator.Send(new GetTodosQuery());

        return Results.Ok(todos);
    })
    .WithName("GetTodos")
    .WithOpenApi();

    app.MapPost("/todos", async (IMediator mediator, [FromBody] CreateTodoCommand createTodoCommand) =>
    {
        var todo = await mediator.Send(new CreateTodoCommand
        {
            Content = createTodoCommand.Content
        });

        return Results.Ok(todo);
    })
    .WithName("AddTodo")
    .WithOpenApi();

    app.Run();
}