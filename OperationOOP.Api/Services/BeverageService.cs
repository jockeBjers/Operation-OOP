namespace OperationOOP.Api.Services;

public interface IBeverageService
{
    Beverage? GetBeverageById(int id);
    List<Beverage> GetAllBeverages();
    List<Beverage> GetSortedBeverages(string sortBy);

    void DecreaseStock(int id, int amount);
}
public class BeverageService : IBeverageService
{
    private readonly IDatabase db;

    public BeverageService(IDatabase db)
    {
        this.db = db;
    }

    // get id
    public Beverage? GetBeverageById(int id)
    {
        return db.Drinks.FirstOrDefault(b => b.Id == id);
    }

    // get all beverages
    public List<Beverage> GetAllBeverages()
    {
        return db.Drinks.ToList();
    }

    public List<Beverage> GetSortedBeverages(string sortBy)
    {
        var drinks = GetAllBeverages();

        switch (sortBy.ToLower())
        {
            case "name":
                return drinks.OrderBy(d => d.Name).ToList();
            case "price":
                return drinks.OrderBy(d => d.Price).ToList();
            case "price descending":
                return drinks.OrderByDescending(d => d.Price).ToList();
            case "volume":
                return drinks.OrderBy(d => d.Volume).ToList();
            case "type":
                return drinks.OrderBy(d => d.GetType().Name).ToList();
            case "quantity":
                return drinks.OrderBy(d => d.Quantity).ToList();
            case "quantity descending":
                return drinks.OrderByDescending(d => d.Quantity).ToList();
            default:
                return drinks;
        }
    }

    public void DecreaseStock(int id, int amount)
    {
        var beverage = GetBeverageById(id);
        if (beverage is null)
        {
            throw new Exception("Beverage not found");
        }
        beverage.RemoveStock(amount);
    }
}
