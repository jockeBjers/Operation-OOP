using System.Reflection.Metadata;

namespace OperationOOP.Api.Endpoints.Sodas;

public class SodaGet : IEndpoint
{

    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/soda/{id}", Handle)
        .WithSummary("soda");

    public record Request(int Id);

    public record Response(
        int Id,
        string Name,
        double Volume,
        decimal Price,
        int Quantity,
        bool IsSugarFree
    );

    private static Response Handle([AsParameters] Request request, IDatabase db)
    {
        var beverage = db.Drinks.Find(b => b.Id == request.Id);
        if (beverage is Soda soda)
        {
            var response = new Response(
                Id: soda.Id,
                Name: soda.Name,
                Volume: soda.Volume,
                Price: soda.Price,
                Quantity: soda.Quantity,
                IsSugarFree: soda.IsSugarFree
            );
            return response;
        }
        return null;
    }
}
