namespace OperationOOP.Api.Endpoints.Beers;
public class BeerRemove : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapDelete("/beer/{id}", Handle)
        .WithSummary("Remove beer");

    public record Response(int Id);

    private static IResult Handle(int id, IBeerService service)
    {
        service.RemoveBeer(id);

        if (service.GetBeerById(id) is null) return Results.NotFound();

        return TypedResults.Ok(new Response(id));
    }
}
