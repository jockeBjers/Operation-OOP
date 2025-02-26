using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Interfaces;


public interface IEntity
{
    int Id { get; set; }
}

public interface IAlcoholicBeverage
{
    // alcoholic beverages need to have alcohol content
    double AlcoholContent { get; set; }
}