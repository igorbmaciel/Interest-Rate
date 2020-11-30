using FluentValidation;
using InterestCalculation.Domain.Base;
using MediatR;

namespace InterestCalculation.Domain.Queries.Request
{
    public class InterestCalculationCommand : BaseCommand, IRequest<double>
    {
        public double InitialValue { get; set; }
        public int Month { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new InterestCalculationValidator().Validate(this);

            return ValidationResult.IsValid;
        }

        public class InterestCalculationValidator : AbstractValidator<InterestCalculationCommand>
        {
            public InterestCalculationValidator()
            {
                RuleFor(e => e.InitialValue)
                    .NotEmpty()
                    .WithState(e => EntityError.InvalidInitialValue);


                RuleFor(e => e.Month)
                    .NotEmpty()
                    .WithState(e => EntityError.InvalidMonth);              
            }

            public enum EntityError
            {
                InvalidInitialValue,
                InvalidMonth
            }
        }
    }
}
