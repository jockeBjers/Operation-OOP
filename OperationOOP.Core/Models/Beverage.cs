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
    protected Beverage(int id, string name, double volume)
    {
        Id = id;
        Name = name;
        Volume = volume;
    }
}

