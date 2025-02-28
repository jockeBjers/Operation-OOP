using FluentValidation;

namespace OperationOOP.Api.Validators
{
    public class SodaValidator : AbstractValidator<Soda>
    {
        public SodaValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Volume).GreaterThan(0);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Quantity).GreaterThan(0);
            RuleFor(x => x.IsSugarFree).NotNull();
        }
    }
}
