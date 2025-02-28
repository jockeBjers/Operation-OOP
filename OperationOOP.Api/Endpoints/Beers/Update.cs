using OperationOOP.Api.Validators;
using OperationOOP.Core.Models;

namespace OperationOOP.Api.Endpoints.Beers;
public class BeerUpdate : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPut("/beer/{id}", Handle)
        .WithSummary("Update beer");

    public record Request(
        int Id,
        string Name,
        decimal Volume,
        decimal Price,
        int Quantity,
        double AlcoholContent,
        BeerType Type,
        BitternessLevel Bitterness
    );

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

    private static IResult Handle(Request request, IBeerService service)
    {
        // Update beer
        var beer = service.UpdateBeer(new Beer(
            id: request.Id,
            name: request.Name,
            volume: request.Volume,
            price: request.Price,
            quantity: request.Quantity,
            alcoholContent: request.AlcoholContent,
            type: request.Type,
            bitterness: request.Bitterness
        ));

        if (beer is null)
        {
            return Results.NotFound();
        }

        var validator = new BeerValidator();
        var result = validator.Validate(beer);

        if (!result.IsValid)
        {
            return Results.BadRequest();
        }

        //return updated beer
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

