using UniqueHabits.Data.Seed;

namespace UniqueHabits.Api.Helpers
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SetPasswordsForSeededUsers(this IApplicationBuilder app, IConfiguration config)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var userName = config.GetValue<string>("SeedUsers:UserName");
                var password = config.GetValue<string>("SeedUsers:Password");
                var passwordSeeder = serviceScope.ServiceProvider.GetService<PasswordSeeder>();
                passwordSeeder.SeedPasswordForSeededUsers(new Tuple<string, string>(userName, password)).GetAwaiter().GetResult();
            }
            return app;
        }
    }
}
