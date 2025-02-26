using OperationOOP.Core.Models;

namespace OperationOOP.Api.Endpoints.Beers;
public class UpdateBeer : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPut("/beer/{id}", Handle)
        .WithSummary("Update beer");

    public record Request(
        int Id,
        string Name,
        double Volume,
        decimal Price,
        int Quantity,
        double AlcoholContent,
        BeerType Type,
        BitternessLevel Bitterness
    );

    public record Response(
        int Id,
        string Name,
        double Volume,
        decimal Price,
        int Quantity,
        double AlcoholContent,
        BeerType Type,
        BitternessLevel Bitterness
    );

    private static Response Handle(Request request, IDatabase db)
    {
        var beer = db.Drinks.OfType<Beer>().FirstOrDefault(b => b.Id == request.Id);
        if (beer is null)
        {
            return null!;
        }
        // Update beer
        beer.Name = request.Name;
        beer.Volume = request.Volume;
        beer.Price = request.Price;
        beer.Quantity = request.Quantity;
        beer.AlcoholContent = request.AlcoholContent;
        beer.Type = request.Type;
        beer.Bitterness = request.Bitterness;

        //return updated beer
        return new Response(
            Id: beer.Id,
            Name: beer.Name,
            Volume: beer.Volume,
            Price: beer.Price,
            Quantity: beer.Quantity,
            AlcoholContent: beer.AlcoholContent,
            Type: beer.Type,
            Bitterness: beer.Bitterness
        );
    }
}

