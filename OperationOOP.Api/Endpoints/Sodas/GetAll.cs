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
        double Volume,
        decimal Price,
        int Quantity,
        bool IsSugarFree
    );

    private static List<Response> Handle(IDatabase db)
    {
        return db.Drinks
            .OfType<Soda>()
            .Select(item => new Response(
                Id: item.Id,
                Name: item.Name,
                Volume: item.Volume,
                Price: item.Price,
                Quantity: item.Quantity,
                IsSugarFree: item.IsSugarFree
            )).ToList();
    }
}
