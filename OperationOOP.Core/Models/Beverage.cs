using OperationOOP.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models;

public abstract class Beverage : IEntity
{

    public int Id { get; set; }
    public string Name { get; set; }
    public double Volume { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    protected Beverage(int id, string name, double volume, decimal price, int quantity)
    {

        // Validate input

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));

        if (volume <= 0)
            throw new ArgumentException("Volume must be greater than zero.", nameof(volume));

        if (price < 0)
            throw new ArgumentException("Price cannot be negative.", nameof(price));

        if (quantity < 0)
            throw new ArgumentException("Quantity cannot be negative.", nameof(quantity));

        Id = id;
        Name = name;
        Volume = volume;
        Price = price;
        Quantity = quantity;
    }

    public void RemoveStock(int quantityToBuy)
    {

        if (quantityToBuy <= 0)
            throw new ArgumentException("Quantity to buy must be greater than zero.");

        if (quantityToBuy > Quantity)
            throw new InvalidOperationException("Not enough stock available.");
        Quantity -= quantityToBuy;
    }

    public void AddStock(int quantityToAdd)
    {
        if (quantityToAdd <= 0)
            throw new ArgumentException("Quantity to add must be greater than zero.");
        Quantity += quantityToAdd;
    }

}

