namespace OperationOOP.Api.Endpoints.Beers;


public class BeerGetAll : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/beer", Handle)
        .WithSummary("beers");

    // Request and Response types
    public record Response(

        int Id,
        string Name,
        decimal Volume,
        decimal Price,
        int Quantity,
        double AlcoholContent,
        BeerType Type,
        BitternessLevel Bitterness
    );

    //Logic
    private static IResult Handle(IBeerService service)
    {
        var list = service.GetAllBeers()
            .Select(item => new Response(
                Id: item.Id,
                Name: item.Name,
                Volume: item.Volume,
                Price: item.Price,
                Quantity: item.Quantity,
                AlcoholContent: item.AlcoholContent,
                Type: item.Type,
                Bitterness: item.Bitterness
            )).ToList();
        return Results.Ok(list);
    }


}


