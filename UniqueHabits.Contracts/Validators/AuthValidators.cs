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
            RuleFor(m => m.ConfirmPassword).NotEmpty().Equal(m => m.Password).WithMessage("Password and confirm password do not match");
        }

        private bool HasUppercase(string password)
        {
            var regex = new Regex("[A-Z]+");
            return !string.IsNullOrEmpty(password) && regex.IsMatch(password);
        }
        
        private bool HasLowercase(string password)
        {
            var regex = new Regex("[a-z]+");
            return !string.IsNullOrEmpty(password) && regex.IsMatch(password);
        }
        
        private bool HasDigit(string password)
        {
            var regex = new Regex("(\\d)+");
            return !string.IsNullOrEmpty(password) && regex.IsMatch(password);
        }
        
        private bool HasSpecialCharacter(string password)
        {
            var regex = new Regex("(\\W)+");
            return !string.IsNullOrEmpty(password) && regex.IsMatch(password);
        }
    }

    public class LoginValidator : AbstractValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(m => m.Email).NotEmpty().EmailAddress();
            RuleFor(m => m.Password).NotEmpty();
        }
    }

    public class AuthUserValidator : AbstractValidator<AuthUserModel>
    {
        public AuthUserValidator()
        {
            RuleFor(m => m.FirstName).NotEmpty();
            RuleFor(m => m.Email).NotEmpty().EmailAddress();
        }
    }
}
