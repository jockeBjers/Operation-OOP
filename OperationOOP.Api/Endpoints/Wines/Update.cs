using System.Reflection.Metadata;

namespace OperationOOP.Api.Endpoints.Wines;

public class WineUpdate : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
       .MapPut("/wine/{id}", Handle)
       .WithSummary("Update wine");

    public record class Request(
        int Id,
        string Name,
        double Volume,
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
        double Volume,
        decimal Price,
        int Quantity,
        double AlcoholContent,
        WineType Type,
        DateTime Bottled,
        WineCharacter Character
    );

    private static Response Handle(Request request, IDatabase db)
    {
        var wine = db.Drinks.OfType<Wine>().FirstOrDefault(b => b.Id == request.Id);
        if (wine is null)
        {
            return null!;
        }
        // Update wine
        wine.Name = request.Name;
        wine.Volume = request.Volume;
        wine.Price = request.Price;
        wine.Quantity = request.Quantity;
        wine.AlcoholContent = request.AlcoholContent;
        wine.Type = request.Type;
        wine.Bottled = request.Bottled;
        wine.Character = request.Character;
        //return updated wine
        return new Response(
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
    }

}
