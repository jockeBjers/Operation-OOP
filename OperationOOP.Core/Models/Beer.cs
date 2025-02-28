using OperationOOP.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models;

public class Beer : Beverage, IAlcoholicBeverage
{
    public double AlcoholContent { get; set; }
    public BeerType Type { get; set; }
    public BitternessLevel Bitterness { get; set; }
    public Beer(int id, string name, decimal volume, decimal price, int quantity, double alcoholContent, BeerType type, BitternessLevel bitterness)
        : base(id, name, volume, price, quantity)
    {
        AlcoholContent = alcoholContent;
        Type = type;
        Bitterness = bitterness;
    }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BeerType
{
    Lager,
    Pilsner,
    Ale,
    Stout,
    IPA
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BitternessLevel
{
    Low,
    Medium,
    High
}