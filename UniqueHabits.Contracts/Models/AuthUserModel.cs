namespace UniqueHabits.Contracts.Models
{
    public class AuthUserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
