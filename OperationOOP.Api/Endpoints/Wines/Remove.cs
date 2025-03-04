using OperationOOP.Api.Services;

namespace OperationOOP.Api.Endpoints.Wines;

public class WineRemove : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapDelete("/wine/{id}", Handle)
        .WithSummary("Remove wine");
    public record Response(int Id);

    private static IResult Handle(int id, IWineService service)
    {
        if (service.GetWineById(id) is null) return Results.NotFound();

        service.RemoveWine(id);

        return TypedResults.Ok(new Response(id));
    }
}
