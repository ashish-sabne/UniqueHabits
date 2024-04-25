using Microsoft.AspNetCore.Identity;
using UniqueHabits.Domain.Aggregates;

namespace UniqueHabits.Data.Seed
{
    public class PasswordSeeder
    {
        private readonly UserManager<AppUser> _userManager;

        public PasswordSeeder(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task SeedPasswordForSeededUsers()
        {
            await SeedPassword("admin.user@test.com", "@dm!nP@$$w0rD");
        }

        private async Task SeedPassword(string email, string password)
        {
            try
            {
                IdentityResult result;
                var user = _userManager.Users.FirstOrDefault(u => u.Email == email);
                if (user == null)
                {
                    return;
                }

                if (user.PasswordHash == null)
                    result = await _userManager.AddPasswordAsync(user, password);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
