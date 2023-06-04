using ToDo.Infrastructure;
using ToDo.Application;
using MediatR;
using ToDo.Application.Features.TodoItems.Commands;
using ToDo.Application.Features.TodoItems.Queries;
using Microsoft.AspNetCore.Mvc;
using ToDo.Api.EndpointDefinitions;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(MyAllowSpecificOrigins,
                              policy =>
                              {
                                  policy
                                    //.WithOrigins("http://localhost:3000")
                                    .AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                              });
    });

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

    app.UseCors(MyAllowSpecificOrigins);

    //TODO: 
    //app.UseHttpsRedirection();

    app.RegisterEndpointDefinitions();

    app.Run();
}

