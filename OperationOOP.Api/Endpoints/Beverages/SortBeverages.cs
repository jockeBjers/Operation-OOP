using Microsoft.AspNetCore.Mvc;

namespace OperationOOP.Api.Endpoints.Beverages;
public class BeverageSort : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/beverages/sort/{sorting}", Handle)
        .WithSummary("Sort beverages by name, price, or quantity");

    public record Response(int Id, string Name, decimal Price, decimal Volume, int Quantity);

    private static IResult Handle([FromQuery] string sortBy, IBeverageService service)
    {
        var sortedDrinks = service.GetSortedBeverages(sortBy);

        var response = sortedDrinks.Select(d => new Response(d.Id, d.Name, d.Price, d.Volume, d.Quantity)).ToList();
        return Results.Ok(response);
    }
}
