namespace OperationOOP.Api.Services;

public interface ISodaService
{
    Soda? GetSodaById(int id);
    List<Soda> GetAllSodas();
    Soda CreateSoda(Soda soda);
    Soda? UpdateSoda(Soda updatedSoda);
    bool RemoveSoda(int id);
}
public class SodaService : ISodaService
{
    private readonly IDatabase db;

    public SodaService(IDatabase db)
    {
        this.db = db;
    }

    public Soda? GetSodaById(int id)
    {
        return db.Drinks.OfType<Soda>().FirstOrDefault(b => b.Id == id);
    }

    public List<Soda> GetAllSodas()
    {
        return db.Drinks.OfType<Soda>().ToList();
    }

    public Soda CreateSoda(Soda soda)
    {
        soda.Id = db.Drinks.Max(b => b.Id) + 1;
        db.Drinks.Add(soda);
        return soda;
    }

    public Soda? UpdateSoda(Soda updatedSoda)
    {
        var soda = GetSodaById(updatedSoda.Id);
        if (soda is null) return null;
        soda.Name = updatedSoda.Name;
        soda.Volume = updatedSoda.Volume;
        soda.Price = updatedSoda.Price;
        soda.RemoveStock(updatedSoda.Quantity);
        soda.IsSugarFree = updatedSoda.IsSugarFree;
        return soda;
    }

    public bool RemoveSoda(int id)
    {
        var soda = GetSodaById(id);
        if (soda is null) return false;
        db.Drinks.Remove(soda);
        return true;
    }


}
