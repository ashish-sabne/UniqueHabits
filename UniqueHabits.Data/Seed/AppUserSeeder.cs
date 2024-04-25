using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqueHabits.Domain.Aggregates;

namespace UniqueHabits.Data.Seed
{
    public static class AppUserSeeder
    {
        public static DataBuilder Seed(this EntityTypeBuilder<AppUser> b)
        {
            return b.HasData(
                new
                {
                    Id = "7A9BC443-C678-4288-8D23-EFE9CE7E5232",
                    FirstName = "Admin",
                    LastName = "User",
                    UserName = "admin.user@test.com",
                    Email = "admin.user@test.com",
                    AccessFailedCount = 0,
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                }
            );
        }
    }
}
