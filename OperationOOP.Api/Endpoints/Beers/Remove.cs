namespace OperationOOP.Api.Endpoints.Beers;
public class BeerRemove : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapDelete("/beer/{id}", Handle)
        .WithSummary("Remove beer");

    public record Response(int Id);

    private static Ok<Response> Handle(int id, IDatabase db)
    {
        var beer = db.Drinks.OfType<Beer>().FirstOrDefault(b => b.Id == id);


        db.Drinks.Remove(beer);

        return TypedResults.Ok(new Response(beer.Id));
    }
}
