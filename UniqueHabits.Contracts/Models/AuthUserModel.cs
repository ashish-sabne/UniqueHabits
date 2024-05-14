using System.Text;

namespace UniqueHabits.Contracts.Models
{
    public class AuthUserModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool EnableNotifications { get; set; }

        public string Name
        {
            get
            {
                var sbName = new StringBuilder(FirstName);

                if (!string.IsNullOrEmpty(LastName))
                {
                    sbName.Append($" {LastName}");
                }

                return sbName.ToString();
            }
        }
    }
}
