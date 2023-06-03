namespace ToDo.Api.EndpointDefinitions;

public interface IEndpointDefinition
{
    void RegisterEndpoints(WebApplication app);
}
