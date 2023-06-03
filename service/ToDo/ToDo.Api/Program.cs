using ToDo.Infrastructure;
using ToDo.Application;
using MediatR;
using ToDo.Application.Features.TodoItems.Commands;
using ToDo.Application.Features.TodoItems.Queries;
using Microsoft.AspNetCore.Mvc;
using ToDo.Api.EndpointDefinitions;

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

    app.RegisterEndpointDefinitions();

    app.Run();
}

