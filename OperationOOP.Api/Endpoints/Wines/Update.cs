using OperationOOP.Api.Validators;

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
        var wine = service.UpdateWine(new Wine(
                id: request.Id,
                name: request.Name,
                volume: request.Volume,
                price: request.Price,
                quantity: request.Quantity,
                alcoholContent: request.AlcoholContent,
                type: request.Type,
                bottled: request.Bottled,
                character: request.Character
            ));

        if (wine is null) return Results.NotFound();

        var validator = new WineValidator();
        var result = validator.Validate(wine);

        if (!result.IsValid) return Results.BadRequest();

        var response = new Response(
             Id: wine.Id,
             Name: wine.Name,
             Volume: wine.Volume,
             Price: wine.Price,
             Quantity: wine.Quantity,
             AlcoholContent: wine.AlcoholContent,
             Type: wine.Type,
             Bottled: wine.Bottled,
             Character: wine.Character
         );
        return Results.Ok(response);
    }
}
