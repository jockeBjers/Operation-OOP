using OperationOOP.Core.Models;

namespace OperationOOP.Core.Data;

public interface IDatabase
{
    List<Beverage> Drinks { get; set; }
}

public class Database : IDatabase
{

    public List<Beverage> Drinks { get; set; }

    public Database()
    {
        Drinks = new List<Beverage>
        {
            // Items for our mock db so we can test the application

            // list of beers
            new Beer(1, "Norrlands", 0.5m, 55, 200,5.5,BeerType.Lager, BitternessLevel.Medium),
            new Beer(2, "Lagunitas", 0.33m, 65, 200,6.5 , BeerType.IPA, BitternessLevel.High),
            new Beer(3, "Guinness", 0.5m, 76, 200, 4.5, BeerType.Stout, BitternessLevel.Low),
            new Beer(4, "Staropramen", 0.33m, 65, 200, 4.0, BeerType.Pilsner, BitternessLevel.Low),
            new Beer(5, "Bombardier", 0.5m, 65, 200, 5.5, BeerType.Ale, BitternessLevel.Medium),

            // list of sodas
            new Soda(6, "Cola", 0.33m, 30, 200, false),
            new Soda(7, "Cola Zero", 0.33m, 30, 200, true),
            new Soda(8, "Sprite", 0.33m, 33, 200, false),
            new Soda(9, "Zingo", 0.33m, 33, 200, false),
            new Soda(10, "Zingo sugar free", 0.33m, 30, 200, true),
        
            // list of wines
            new Wine(11, "Tony Hawk pro skater 1 wine", 0.4m, 85, 50,13.5, WineType.Red, DateTime.Now.AddYears(-2), WineCharacter.Dry),
            new Wine(12, "Riesling", 0.4m, 75, 50, 12.0, WineType.White, DateTime.Now.AddYears(-1), WineCharacter.Fruity),
            new Wine(13, "Summertime wine", 0.4m, 85, 50, 11.5, WineType.Rose, DateTime.Now.AddYears(-1), WineCharacter.Medium),
            new Wine(14, "Sparkling Queen", 0.4m, 95, 50, 12.0, WineType.Sparkling, DateTime.Now.AddYears(-1), WineCharacter.Fruity),
        };

    }
}
