using FluentValidation;
using System.Text.RegularExpressions;
using UniqueHabits.Contracts.Models;

namespace UniqueHabits.Contracts.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterModel>
    {
        public RegisterValidator()
        {
            RuleFor(m => m.FirstName).NotEmpty().MaximumLength(20);
            RuleFor(m => m.LastName).MaximumLength(20);
            RuleFor(m => m.Email).NotEmpty().EmailAddress();
            RuleFor(m => m.Password).NotEmpty()
                .Must(HasUppercase).WithMessage("Password must contain at least one uppercase letter")
                .Must(HasLowercase).WithMessage("Password must contain at least one lowercase letter")
                .Must(HasDigit).WithMessage("Password must contain at least one number")
                .Must(HasSpecialCharacter).WithMessage("Password must contain at least one special character");
        }

        private bool HasUppercase(string password)
        {
            var regex = new Regex("[A-Z]+");
            return regex.IsMatch(password);
        }
        
        private bool HasLowercase(string password)
        {
            var regex = new Regex("[a-z]+");
            return regex.IsMatch(password);
        }
        
        private bool HasDigit(string password)
        {
            var regex = new Regex("(\\d)+");
            return regex.IsMatch(password);
        }
        
        private bool HasSpecialCharacter(string password)
        {
            var regex = new Regex("(\\W)+");
            return regex.IsMatch(password);
        }
    }
}
