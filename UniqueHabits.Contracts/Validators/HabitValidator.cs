using FluentValidation;
using UniqueHabits.Shared.Enums;

namespace UniqueHabits.Contracts.Validators
{
    public class HabitValidator : AbstractValidator<HabitModel>
    {
        public HabitValidator() 
        {
            RuleFor(h => h.SystemName).NotEmpty();
            RuleFor(h => h.MeasurableResult).NotEmpty();
            RuleFor(h => h.StartDate).NotEmpty().GreaterThanOrEqualTo(DateTime.Today);
            RuleFor(h => h.Category).NotEmpty();
            RuleFor(h => h.CategoryDescription).NotEmpty()
                .When(h => h.Category == HabitCategory.Other);
            RuleFor(h => h.CategoryDescription).Empty()
                .When(h => h.Category != HabitCategory.Other);
        }
    }
    
    public class ImplementationDetailsValidator : AbstractValidator<ImplementationDetails>
    {
        public ImplementationDetailsValidator() 
        {
            RuleFor(id => id.How).NotEmpty();
            RuleFor(id => id.WithWhat).NotEmpty();
            RuleFor(id => id.When).NotEmpty();
            RuleFor(id => id.Where).NotEmpty();
            RuleFor(id => id.WithWhom).NotEmpty();
        }
    }


}
