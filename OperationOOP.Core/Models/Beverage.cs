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
    public decimal Volume { get; set; }
    public decimal Price { get; set; }

    private int _quantity;
    public int Quantity
    {
        get => _quantity;
        private set
        {
            if (value < 0)
                throw new ArgumentException("Quantity must be positive");
            _quantity = value;
        }
    }



    public Beverage(int id, string name, decimal volume, decimal price, int quantity)
    {

        Id = id;
        Name = name;
        Volume = volume;
        Price = price;
        Quantity = quantity;

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");

        if (volume < 0)
            throw new ArgumentException("Volume must be positive");

        if (price < 0)
            throw new ArgumentException("Price must be positive");
    }

    public void RemoveStock(int quantityToRemove)
    {
        if (quantityToRemove < 0)
            throw new ArgumentException("Quantity must be positive");

        if (quantityToRemove > Quantity)
            throw new InvalidOperationException("Not enough in stock available.");
        _quantity -= quantityToRemove;
    } 
}

