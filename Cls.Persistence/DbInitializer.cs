using Microsoft.EntityFrameworkCore;

namespace Classifiers.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(ClassifiersDbContext context)
        {
            context.Database.EnsureCreated(); // проверяет существует ли бд если нет то создает
        }
        
        public static async Task InitializeAsync(ClassifiersDbContext context)
        {
            // Применяем миграции асинхронно (создаёт БД, если её нет, и применяет миграции)
            await context.Database.MigrateAsync();
        }
    }
}
