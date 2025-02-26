using System.Reflection.Metadata;

namespace OperationOOP.Api.Endpoints.Sodas;

public class SodaCreate : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/Soda", Handle)
        .WithSummary("Create a new soda");

    public record Request(
        string Name,
        double Volume,
        decimal Price,
        int Quantity,
        bool IsSugarFree
    );

    public record Response(int Id);

    private static Ok<Response> Handle(Request request, IDatabase db)
    {
        var soda = new Soda(
            id: db.Drinks.Max(b => b.Id) + 1,
            name: request.Name,
            volume: request.Volume,
            price: request.Price,
            quantity: request.Quantity,
            isSugarFree: request.IsSugarFree
        );

        db.Drinks.Add(soda);

        return TypedResults.Ok(new Response(soda.Id));
    }
}
