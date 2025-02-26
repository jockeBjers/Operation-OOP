using System.Reflection.Metadata;

namespace OperationOOP.Api.Endpoints.Wines;

public class WineCreate : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/Wines", Handle)
        .WithSummary("Create new wine");


    public record Request(
        string Name,
        double Volume,
        decimal Price,
        int Quantity,
        double AlcoholContent,
        WineType Type,
        DateTime Bottled,
        WineCharacter Character
    );
    public record Response(int Id);

    private static Ok<Response> Handle(Request request, IDatabase db)
    {
        var wine = new Wine(
            id: db.Drinks.Max(b => b.Id) + 1,
            name: request.Name,
            volume: request.Volume,
            price: request.Price,
            quantity: request.Quantity,
            alcoholContent: request.AlcoholContent,
            type: request.Type,
            bottled: request.Bottled,
            character: request.Character
        );
        db.Drinks.Add(wine);
        return TypedResults.Ok(new Response(wine.Id));
    }
}
