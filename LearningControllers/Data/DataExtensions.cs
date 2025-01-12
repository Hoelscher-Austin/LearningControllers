using Microsoft.EntityFrameworkCore;

namespace LearningControllers.Data
{
    public static class DataExtensions
    {

        public static async Task MigrateDbAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<LearningDbContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
