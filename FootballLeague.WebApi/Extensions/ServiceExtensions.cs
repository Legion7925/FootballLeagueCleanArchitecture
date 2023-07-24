using FootballLeague.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static async Task MigrateDatabaseIfDoesntExist(this WebApplication builder)
        {
            using (var scope = builder.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await db.Database.MigrateAsync();
            }
        }
    }
}
