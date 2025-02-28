namespace OperationOOP.Api.Services;
public interface IBeerService
{
    Beer? GetBeerById(int id);
    List<Beer> GetAllBeers();
    Beer CreateBeer(Beer beer);
    Beer? UpdateBeer(Beer updatedBeer);
    bool RemoveBeer(int id);
}


public class BeerService : IBeerService
{
    private readonly IDatabase db;

    public BeerService(IDatabase db)
    {
        this.db = db;
    }

    public Beer? GetBeerById(int id)
    {
        return db.Drinks.OfType<Beer>().FirstOrDefault(b => b.Id == id);
    }

    public List<Beer> GetAllBeers()
    {
        return db.Drinks.OfType<Beer>().ToList();
    }

    public Beer CreateBeer(Beer beer)
    {
        beer.Id = db.Drinks.Max(b => b.Id) + 1;
        db.Drinks.Add(beer);
        return beer;
    }

    public Beer? UpdateBeer(Beer updatedBeer)
    {
        var beer = GetBeerById(updatedBeer.Id);

        if (beer is null) return null;

        beer.Name = updatedBeer.Name;
        beer.Volume = updatedBeer.Volume;
        beer.Price = updatedBeer.Price;
        beer.RemoveStock(updatedBeer.Quantity);
        beer.AlcoholContent = updatedBeer.AlcoholContent;
        beer.Type = updatedBeer.Type;
        beer.Bitterness = updatedBeer.Bitterness;

        return beer;
    }

    public bool RemoveBeer(int id)
    {
        var beer = GetBeerById(id);
        if (beer is null) return false;
        db.Drinks.Remove(beer);
        return true;
    }
}
