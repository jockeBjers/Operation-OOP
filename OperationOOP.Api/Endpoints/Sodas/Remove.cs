using System.Reflection.Metadata;

namespace OperationOOP.Api.Endpoints.Sodas;

public class SodaRemove : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapDelete("/soda/{id}", Handle)
        .WithSummary("Remove soda");

    public record Response(int Id);


    private static Ok<Response> Handle(int id, IDatabase db)
    {
        var soda = db.Drinks.OfType<Soda>().FirstOrDefault(b => b.Id == id);
        db.Drinks.Remove(soda);
        return TypedResults.Ok(new Response(soda.Id));
    }

}
