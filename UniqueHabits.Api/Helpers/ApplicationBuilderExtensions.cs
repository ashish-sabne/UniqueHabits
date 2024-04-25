using UniqueHabits.Data.Seed;

namespace UniqueHabits.Api.Helpers
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SetPasswordsForSeededUsers(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var passwordSeeder = serviceScope.ServiceProvider.GetService<PasswordSeeder>();
                passwordSeeder.SeedPasswordForSeededUsers().GetAwaiter().GetResult();
            }
            return app;
        }
    }
}
