using Microsoft.AspNetCore.Routing;
using Presentation.Endpoints;

namespace Presentation;

public static class DependencyInjection
{
    public static void MapEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapTodoEndpoints();
    }
}
