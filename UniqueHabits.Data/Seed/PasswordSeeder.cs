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

        public async Task SeedPasswordForSeededUsers(params Tuple<string, string>[] credentials)
        {
            foreach (var cred in credentials)
            {
                await SeedPassword(cred.Item1, cred.Item2); 
            }
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
