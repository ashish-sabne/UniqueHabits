using Microsoft.AspNetCore.Identity;

namespace UniqueHabits.Domain.Aggregates
{
    public class AppUser : IdentityUser
    {
        protected AppUser(): base() { }

        private AppUser(string firstName, string lastName, string email) : base()
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = email;
            Email = email;
        }

        public string FirstName { get; private set; }
        public string? LastName { get; private set; }

        public static AppUser Create(string firstName, string lastName, string email)
        {
            return new AppUser(firstName, lastName, email);
        }
    }
}
