using OperationOOP.Api.Validators;
using System.Reflection.Metadata;

namespace OperationOOP.Api.Endpoints.Sodas;

public class SodaCreate : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/Soda", Handle)
        .WithSummary("Create a new soda");

    public record Request(
        string Name,
        decimal Volume,
        decimal Price,
        int Quantity,
        bool IsSugarFree
    );

    public record Response(int Id);

    private static IResult Handle(Request request, ISodaService service)
    {
        var soda = new Soda(
            id: 0,
            name: request.Name,
            volume: request.Volume,
            price: request.Price,
            quantity: request.Quantity,
            isSugarFree: request.IsSugarFree
        );

        var validator = new SodaValidator();
        var result = validator.Validate(soda);

        if (!result.IsValid)
        {
            return TypedResults.BadRequest(result.Errors);
        }

        soda = service.CreateSoda(soda);
        return TypedResults.Ok(new Response(soda.Id));
    }
}
