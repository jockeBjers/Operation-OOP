namespace OperationOOP.Api.Services;

public interface IWineService
{
    Wine? GetWineById(int id);
    List<Wine> GetAllWines();
    Wine CreateWine(Wine wine);
    Wine? UpdateWine(Wine updatedWine);
    bool RemoveWine(int id);
}

public class WineService : IWineService
{
    private readonly IDatabase db;

    public WineService(IDatabase db)
    {
        this.db = db;
    }

    public Wine? GetWineById(int id)
    {
        return db.Drinks.OfType<Wine>().FirstOrDefault(b => b.Id == id);
    }

    public List<Wine> GetAllWines()
    {
        return db.Drinks.OfType<Wine>().ToList();
    }

    public Wine CreateWine(Wine wine)
    {
        wine.Id = db.Drinks.Max(b => b.Id) + 1;
        db.Drinks.Add(wine);
        return wine;
    }

    public Wine? UpdateWine(Wine updatedWine)
    {
        var wine = GetWineById(updatedWine.Id);
        if (wine is null) return null;

        wine.Name = updatedWine.Name;
        wine.Volume = updatedWine.Volume;
        wine.Price = updatedWine.Price;
        wine.RemoveStock(updatedWine.Quantity);
        wine.AlcoholContent = updatedWine.AlcoholContent;
        wine.Type = updatedWine.Type;
        wine.Bottled = updatedWine.Bottled;
        wine.Character = updatedWine.Character;

        return wine;
    }

    public bool RemoveWine(int id)
    {
        var wine = GetWineById(id);
        if (wine is null) return false;

        db.Drinks.Remove(wine);
        return true;
    }
}
