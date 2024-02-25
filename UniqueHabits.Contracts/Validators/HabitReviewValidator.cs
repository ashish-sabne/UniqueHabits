using FluentValidation;
using UniqueHabits.Contracts.Models;
using UniqueHabits.Shared.Enums;

namespace UniqueHabits.Contracts.Validators
{
    public class HabitReviewValidator : AbstractValidator<HabitReviewModel>
    {
        public HabitReviewValidator() 
        {
            RuleFor(h => h.Result).NotEmpty();
            RuleFor(h => h.CustomizationDescription).NotEmpty();
            RuleFor(h => h.WithWhat).NotEmpty().When(h => h.CustomizationCategory == CustomizationCategory.WithWhat);
            RuleFor(h => h.When).NotEmpty().When(h => h.CustomizationCategory == CustomizationCategory.When);
            RuleFor(h => h.Where).NotEmpty().When(h => h.CustomizationCategory == CustomizationCategory.Where);
            RuleFor(h => h.WithWhom).NotEmpty().When(h => h.CustomizationCategory == CustomizationCategory.WithWhom);
        }
    }
}
