using OperationOOP.Api.Validators;
using System.Reflection.Metadata;

namespace OperationOOP.Api.Endpoints.Wines;

public class WineCreate : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/Wines", Handle)
        .WithSummary("Create new wine");


    public record Request(
        string Name,
        decimal Volume,
        decimal Price,
        int Quantity,
        double AlcoholContent,
        WineType Type,
        DateTime Bottled,
        WineCharacter Character
    );
    public record Response(int Id);

    private static IResult Handle(Request request, IWineService service)
    {
        var wine = new Wine(
            id: 0,
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

        wine = service.CreateWine(wine);
        return TypedResults.Ok(new Response(wine.Id));
    }
}
