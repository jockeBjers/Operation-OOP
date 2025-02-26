namespace OperationOOP.Api.Endpoints.Wines;

public class WineRemove : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapDelete("/wine/{id}", Handle)
        .WithSummary("Remove wine");
    public record Response(int Id);

    private static Ok<Response> Handle(int id, IDatabase db)
    {
        var wine = db.Drinks.OfType<Wine>().FirstOrDefault(b => b.Id == id);
        db.Drinks.Remove(wine);
        return TypedResults.Ok(new Response(wine.Id));
    }
}
