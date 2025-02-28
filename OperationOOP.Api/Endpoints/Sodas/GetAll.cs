using System.Reflection.Metadata;

namespace OperationOOP.Api.Endpoints.Sodas;

public class SodaGetAll : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/Soda", Handle)
        .WithSummary("Sodas");

    public record Response(
        int Id,
        string Name,
        decimal Volume,
        decimal Price,
        int Quantity,
        bool IsSugarFree
    );

    private static IResult Handle(ISodaService service)
    {
        var list = service.GetAllSodas()
             .Select(item => new Response(
                 Id: item.Id,
                 Name: item.Name,
                 Volume: item.Volume,
                 Price: item.Price,
                 Quantity: item.Quantity,
                 IsSugarFree: item.IsSugarFree
             )).ToList();
        return Results.Ok(list);
    }
}
