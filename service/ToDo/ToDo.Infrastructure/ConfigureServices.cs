using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Common.Services;
using ToDo.Application.Features.TodoItems;
using ToDo.Infrastructure.Data;
using ToDo.Infrastructure.Data.Repositories;
using ToDo.Infrastructure.Services;

namespace ToDo.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInftrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ToDoContext>(options => options.UseInMemoryDatabase("InMemoryDb"));
        services.AddSingleton<IDateTimeService, DataTimeService>();
        services.AddScoped<ITodoItemRepository, TodoItemRepository>();

        return services;
    }
}
