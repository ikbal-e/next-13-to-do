namespace ToDo.Api.EndpointDefinitions;

public static class ConfigureEndpoints
{
    public static void RegisterEndpointDefinitions(this WebApplication app)
    {
        var endpointDefinitions = typeof(Program).Assembly
            .GetTypes()
            .Where(x => x.IsAssignableTo(typeof(IEndpointDefinition))
                && x is
                {
                    IsAbstract: false,
                    IsInterface: false
                })
            .Select(Activator.CreateInstance)
            .Cast<IEndpointDefinition>();

        foreach (var endpointDefinition in endpointDefinitions)
        {
            endpointDefinition.RegisterEndpoints(app);
        }
    }
}
