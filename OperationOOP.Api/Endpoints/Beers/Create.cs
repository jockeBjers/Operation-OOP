namespace OperationOOP.Api.Endpoints.Beers;
public class CreateBeer : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/beer", Handle)
        .WithSummary("Create a new beer");

    public record Request(
        string Name,
        double Volume,
        decimal Price,
        int Quantity,
        double AlcoholContent,
        BeerType Type,
        BitternessLevel Bitterness
    );

    public record Response(int Id);

    private static Ok<Response> Handle(Request request, IDatabase db)
    {
        // add 
        var beer = new Beer(
              id: db.Drinks.Max(b => b.Id) + 1,
              name: request.Name,
              volume: request.Volume,
              price: request.Price,
              quantity: request.Quantity,
              alcoholContent: request.AlcoholContent,
              type: request.Type,
              bitterness: request.Bitterness
          );

        db.Drinks.Add(beer);

        return TypedResults.Ok(new Response(beer.Id));
    }
}
