using Microsoft.EntityFrameworkCore;
using Classifiers.Domain;
using Classifiers.Persistence.EntityTypeConfigurations;
using Classifiers.Application.Interfaces;

namespace Classifiers.Persistence
{
    public class ClassifiersDbContext : DbContext, IClassifiersDbContext
    {
        public DbSet<Classifier> Classifiers { get; set; }

        //принимает параметр DbContextOptions<ClassifiersDbContext> options, который содержит настройки для контекста базы данных
        // base(options) - передает эти настройки в базовый класс DbContext
        public ClassifiersDbContext(DbContextOptions<ClassifiersDbContext> options)
            : base(options) { }

        // OnModelCreating используется для настройки модели базы данных, (подключение и т.п.)
        // ApplyConfiguration - применяется конфигурация для Classifier, выност настройки таблицы в класс ClassifierConfiguration (отделяем конфигурацию сущности Classifier от основного контекста базы данных)
        // base.OnModelCreating(modelBuilder) - вызывает базовую реализацию метода для стандартных настроек
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClassifierConfiguration());
            modelBuilder.Entity<Classifier>()
                .HasMany(c => c.Children)
                .WithOne(c => c.Parent)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder); //  стандартные настройки будут так же применены
        }
    }
}
