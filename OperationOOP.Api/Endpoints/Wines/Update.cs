using OperationOOP.Api.Validators;
using OperationOOP.Core.Models;

namespace OperationOOP.Api.Endpoints.Wines;

public class WineUpdate : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
       .MapPut("/wine/{id}", Handle)
       .WithSummary("Update wine");

    public record class Request(
        int Id,
        string Name,
        decimal Volume,
        decimal Price,
        int Quantity,
        double AlcoholContent,
        WineType Type,
        DateTime Bottled,
        WineCharacter Character
    );

    public record class Response(
        int Id,
        string Name,
        decimal Volume,
        decimal Price,
        int Quantity,
        double AlcoholContent,
        WineType Type,
        DateTime Bottled,
        WineCharacter Character
    );

    private static IResult Handle(Request request, IWineService service)
    {
        var wine = new Wine(
            id: request.Id,
            name: request.Name,
            volume: request.Volume,
            price: request.Price,
            quantity: request.Quantity,
            alcoholContent: request.AlcoholContent,
            type: request.Type,
            bottled: request.Bottled,
            character: request.Character
            );

        var validator = new WineValidator();
        var result = validator.Validate(wine);

        if (!result.IsValid)
        {
            return Results.BadRequest(result.Errors.Select(x => new
            {
                Field = x.PropertyName,
                Message = x.ErrorMessage
            }));
        }

        wine = service.UpdateWine(wine);

        if (wine == null)
        {
            return Results.NotFound();
        }

        var response = new Response
        (
            wine.Id,
            wine.Name,
            wine.Volume,
            wine.Price,
            wine.Quantity,
            wine.AlcoholContent,
            wine.Type,
            wine.Bottled,
            wine.Character
        );

        return TypedResults.Ok(response);
    }
}
