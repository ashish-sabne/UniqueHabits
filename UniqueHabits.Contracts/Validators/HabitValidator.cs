using FluentValidation;

namespace UniqueHabits.Contracts.Validators
{
    public class HabitValidator : AbstractValidator<Habit>
    {
        public HabitValidator() 
        {
            RuleFor(h => h.SystemName).NotEmpty();
            RuleFor(h => h.MeasurableResult).NotEmpty();
            RuleFor(h => h.StartDate).NotEmpty().GreaterThanOrEqualTo(DateTime.Today);
            RuleFor(h => h.Category).NotEmpty();
            RuleFor(h => h.CategoryDescription).NotEmpty()
                .When(h => h.Category == Enums.HabitCategory.Other);
            RuleFor(h => h.CategoryDescription).Empty()
                .When(h => h.Category != Enums.HabitCategory.Other);
        }
    }
}
