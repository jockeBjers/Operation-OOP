using OperationOOP.Core.Models;
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
        decimal Volume,
        decimal Price,
        int Quantity,
        bool IsSugarFree
    );

    private static IResult Handle([AsParameters] Request request, ISodaService service)
    {
        var soda = service.GetSodaById(request.Id);
        if (soda is null) return Results.NotFound();

        var response = new Response(
              Id: soda.Id,
              Name: soda.Name,
              Volume: soda.Volume,
              Price: soda.Price,
              Quantity: soda.Quantity,
              IsSugarFree: soda.IsSugarFree
          );
        return Results.Ok(response);
    }
}
