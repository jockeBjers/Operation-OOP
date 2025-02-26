using OperationOOP.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models;

class Soda : Beverage
{
    public bool IsSugarFree { get; set; }
    public Soda(int id, string name, double volume, decimal price, int quantity, bool isSugarFree)
           : base(id, name, volume, price, quantity)
    {

        IsSugarFree = isSugarFree;

    }
}
