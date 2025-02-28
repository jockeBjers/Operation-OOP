﻿using FluentValidation;

namespace OperationOOP.Api.Validators;

public class BeerValidator : AbstractValidator<Beer>
{
    public BeerValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Volume).GreaterThan(0);
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.AlcoholContent).GreaterThan(0);
    }
}
