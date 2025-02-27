using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Classifiers.Domain;


namespace Classifiers.Persistence.EntityTypeConfigurations
{
    class ClassifierConfiguration : IEntityTypeConfiguration<Classifier>
    {
        public void Configure(EntityTypeBuilder<Classifier> builder)
        {
            builder.HasKey(cls => cls.Id); // указывает что Id является первичным ключом таблицы.
            builder.HasIndex(cls => cls.Id).IsUnique(); //создает уникальный индекс для Id
        }
    }
}
