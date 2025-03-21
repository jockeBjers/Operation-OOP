﻿using OperationOOP.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models;

public class Wine : Beverage, IAlcoholicBeverage
{
    public double AlcoholContent { get; set; }
    public WineType Type { get; set; }
    public DateTime Bottled { get; set; }
    public WineCharacter Character { get; set; }

    public Wine(int id, string name, decimal volume, decimal price, int quantity, double alcoholContent, WineType type, DateTime bottled, WineCharacter character)
        : base(id, name, volume, price, quantity)
    {
        AlcoholContent = alcoholContent;
        Type = type;
        Bottled = bottled;
        Character = character;
    }
}
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum WineType
{
    Red,
    White,
    Rose,
    Sparkling
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum WineCharacter
{
    Dry,
    Medium,
    Fruity
}

