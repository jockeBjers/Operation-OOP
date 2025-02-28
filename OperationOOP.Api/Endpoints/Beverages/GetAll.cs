using System.Reflection.Metadata;

namespace OperationOOP.Api.Endpoints.Beverages;

public class BeverageGetAll : IEndpoint
{


    public static void MapEndpoint(IEndpointRouteBuilder app) => app
      .MapGet("/beverage", Handle)
      .WithSummary("beverages");


    public record Response(
        int Id,
        string Name,
        decimal Volume,
        decimal Price
        );

    private static IResult Handle(IBeverageService service)
    {
        var list = service.GetAllBeverages()
             .Select(item => new Response(
                 Id: item.Id,
                 Name: item.Name,
                 Volume: item.Volume,
                 Price: item.Price
             )).ToList();
        return Results.Ok(list);
    }
}




