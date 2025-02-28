using FluentValidation;
using OperationOOP.Api.Validators;

namespace OperationOOP.Api.Endpoints.Beers;
public class BeerCreate : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/beer", Handle)
        .WithSummary("Create a new beer");

    public record Request(
        string Name,
        decimal Volume,
        decimal Price,
        int Quantity,
        double AlcoholContent,
        BeerType Type,
        BitternessLevel Bitterness
    );

    public record Response(int Id);


    // change the return type to IResult so we can return NotFound and not just Ok
    private static IResult Handle(Request request, IBeerService service)
    {
        var beer = new Beer(
              id: 0,
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
            return Results.BadRequest();
        }

        beer = service.CreateBeer(beer);
        return TypedResults.Ok(new Response(beer.Id));
    }
}
