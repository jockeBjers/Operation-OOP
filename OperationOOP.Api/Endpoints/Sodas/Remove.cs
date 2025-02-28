using System.Reflection.Metadata;

namespace OperationOOP.Api.Endpoints.Sodas;

public class SodaRemove : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapDelete("/soda/{id}", Handle)
        .WithSummary("Remove soda");

    public record Response(int Id);

    private static IResult Handle(int id, ISodaService service)
    {
        service.RemoveSoda(id);

        if (service.GetSodaById(id) is null) return Results.NotFound();

        return TypedResults.Ok(new Response(id));
    }
}
