using System.Reflection.Metadata;

namespace OperationOOP.Api.Endpoints.Sodas;

public class SodaUpdate : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPut("/soda/{id}", Handle)
        .WithSummary("Update soda");

    public record Request(
        int Id,
        string Name,
        double Volume,
        decimal Price,
        int Quantity,
        bool IsSugarFree
    );

    public record Response(
        int Id,
        string Name,
        double Volume,
        decimal Price,
        int Quantity,
        bool IsSugarFree
    );

    private static Response Handle(Request request, IDatabase db)
    {
        var soda = db.Drinks.OfType<Soda>().FirstOrDefault(b => b.Id == request.Id);
        if (soda is null)
        {
            return null!;
        }

        // Update soda
        soda.Name = request.Name;
        soda.Volume = request.Volume;
        soda.Price = request.Price;
        soda.Quantity = request.Quantity;
        soda.IsSugarFree = request.IsSugarFree;

        //return updated soda
        return new Response(
            Id: soda.Id,
            Name: soda.Name,
            Volume: soda.Volume,
            Price: soda.Price,
            Quantity: soda.Quantity,
            IsSugarFree: soda.IsSugarFree
        );
    }
}
