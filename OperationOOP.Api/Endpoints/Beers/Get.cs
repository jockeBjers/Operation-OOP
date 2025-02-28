using OperationOOP.Core.Models;

namespace OperationOOP.Api.Endpoints.Beers;

public class BeerGet : IEndpoint
{

    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/beer/{id}", Handle)
        .WithSummary("beers");

    public record Request(int Id);

    public record Response(

        int Id,
        string Name,
        decimal Volume,
        decimal Price,
        int Quantity,
        double AlcoholContent,
        BeerType Type,
        BitternessLevel Bitterness
    );

    private static IResult Handle([AsParameters] Request request, IBeerService service)
    {
        var beer = service.GetBeerById(request.Id);
        if (beer is null) return Results.NotFound();

        var response = new Response(
            Id: beer.Id,
            Name: beer.Name,
            Volume: beer.Volume,
            Price: beer.Price,
            Quantity: beer.Quantity,
            AlcoholContent: beer.AlcoholContent,
            Type: beer.Type,
            Bitterness: beer.Bitterness
        );

        return Results.Ok(response);
    }
}
