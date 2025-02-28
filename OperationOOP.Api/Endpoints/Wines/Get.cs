using System.Reflection.Metadata;

namespace OperationOOP.Api.Endpoints.Wines;

public class WineGet : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
   .MapGet("/wine/{id}", Handle)
   .WithSummary("wine");

    public record Request(int Id);
    public record Response(
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
    private static IResult Handle([AsParameters] Request request, IWineService service)
    {
        var wine = service.GetWineById(request.Id);
        if (wine is null) return null;

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
