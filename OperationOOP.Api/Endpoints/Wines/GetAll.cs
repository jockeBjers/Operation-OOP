using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace OperationOOP.Api.Endpoints.Wines;

public class WineGetAll : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
   .MapGet("/wine", Handle)
   .WithSummary("wine");

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

    private static IResult Handle(IWineService service)
    {
        var list = service.GetAllWines()
              .Select(item => new Response(
                  Id: item.Id,
                  Name: item.Name,
                  Volume: item.Volume,
                  Price: item.Price,
                  Quantity: item.Quantity,
                  AlcoholContent: item.AlcoholContent,
                  Type: item.Type,
                  Bottled: item.Bottled,
                  Character: item.Character
              )).ToList();
        return Results.Ok(list);
    }

}
