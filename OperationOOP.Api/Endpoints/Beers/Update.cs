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
        var beer = new Beer(
               id: request.Id,
               name: request.Name,
               volume: request.Volume,
               price: request.Price,
               quantity: request.Quantity,
               alcoholContent: request.AlcoholContent,
               type: request.Type,
               bitterness: request.Bitterness
           );

        var validator = new BeerValidator();
        var result = validator.Validate(beer);

        if (!result.IsValid)
        {
            return Results.BadRequest(result.Errors.Select(x => new
            {
                Field = x.PropertyName,
                Message = x.ErrorMessage
            }));
        }

        beer = service.UpdateBeer(beer);

        if (beer is null)
        {
            return Results.NotFound();
        }

        var response = new Response(
            beer.Id,
            beer.Name,
            beer.Volume,
            beer.Price,
            beer.Quantity,
            beer.AlcoholContent,
            beer.Type,
            beer.Bitterness
        );
        return TypedResults.Ok(response);
    }
}

