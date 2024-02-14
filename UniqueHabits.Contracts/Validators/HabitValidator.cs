using FluentValidation;
using UniqueHabits.Contracts.Models;
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
            RuleFor(i => i.WithWhat).NotEmpty();
            RuleFor(i => i.When).NotEmpty();
            RuleFor(i => i.Where).NotEmpty();
            RuleFor(i => i.WithWhom).NotEmpty();
            RuleForEach(i => i.Steps).NotEmpty().SetValidator(new ImplementationStepValidator());
        }
    }

    public class ImplementationStepValidator : AbstractValidator<ImplementationStep>
    {
        public ImplementationStepValidator()
        {
            RuleFor(s => s.Step).NotEmpty();
        }
    }


}
