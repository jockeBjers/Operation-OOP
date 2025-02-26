using System.Reflection.Metadata;

namespace OperationOOP.Api.Endpoints.Wines
{
    public class WineGet : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
       .MapGet("/wine/{id}", Handle)
       .WithSummary("wine");

        public record Request(int Id);
        public record Response(
            int Id,
            string Name,
            double Volume,
            decimal Price,
            int Quantity,
            double AlcoholContent,
            WineType Type,
            DateTime Bottled,
            WineCharacter Character
        );
        private static Response Handle([AsParameters] Request request, IDatabase db)
        {
            var beverage = db.Drinks.Find(b => b.Id == request.Id);
            if (beverage is Wine wine)
            {
                var response = new Response(
                    Id: wine.Id,
                    Name: wine.Name,
                    Volume: wine.Volume,
                    Price: wine.Price,
                    Quantity: wine.Quantity,
                    AlcoholContent: wine.AlcoholContent,
                    Type: wine.Type,
                    Bottled: wine.Bottled,
                    Character: wine.Character
                );
                return response;
            }
            return null;
        }
    }
}
