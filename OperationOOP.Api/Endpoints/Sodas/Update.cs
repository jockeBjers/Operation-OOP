using OperationOOP.Api.Validators;
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
        decimal Volume,
        decimal Price,
        int Quantity,
        bool IsSugarFree
    );

    public record Response(
        int Id,
        string Name,
        decimal Volume,
        decimal Price,
        int Quantity,
        bool IsSugarFree
    );

    private static IResult Handle(Request request, ISodaService service)
    {
        var soda = service.UpdateSoda(new Soda(
            id: request.Id,
            name: request.Name,
            volume: request.Volume,
            price: request.Price,
            quantity: request.Quantity,
            isSugarFree: request.IsSugarFree
        ));

        if (soda is null)
        {
            return Results.NotFound();
        }

        var validator = new SodaValidator();
        var result = validator.Validate(soda);

        if (!result.IsValid)
        {
            return Results.BadRequest();
        }

        var response = new Response(
            Id: soda.Id,
            Name: soda.Name,
            Volume: soda.Volume,
            Price: soda.Price,
            Quantity: soda.Quantity,
            IsSugarFree: soda.IsSugarFree
        );
        return TypedResults.Ok(response);
    }
}
