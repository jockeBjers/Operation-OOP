namespace OperationOOP.Api.Endpoints.Beverages;

public class BeverageDecreaseStock : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPut("/beverages/{id}/decrease", Handle)
        .WithSummary("Decrease the stock of a beverage");

    public record Request(int Amount);
    public record Response(int NewQuantity);

    private static IResult Handle(int id, Request request, IBeverageService service)
    {
        var beverage = service.GetBeverageById(id);
        if (beverage == null)
        {
            return Results.NotFound();
        }

        service.DecreaseStock(id, request.Amount);

        return Results.Ok(new Response(beverage.Quantity));
    }
}
