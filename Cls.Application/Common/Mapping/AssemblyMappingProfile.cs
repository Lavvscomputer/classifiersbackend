using System.Reflection;
using AutoMapper;

namespace Classifiers.Application.Common.Mapping
{
    public class AssemblyMappingProfile : Profile //класс для настройки маппингов между объектами библиотеки AutoMapper
    {
        public AssemblyMappingProfile(Assembly assembly) => // Конструктор 
            AssemblyMappingsFromAssembly(assembly);
        private void AssemblyMappingsFromAssembly(Assembly assembly)
        {
            //GetExportedTypes() — получает все публичные типы из сборки ( классы, интерфейсы, структуры, перечисления и делегаты, которые объявлены с модификатором доступа public )
            // IsGenericType — проверяет, является ли интерфейс generic*ом
            // GetGenericTypeDefinition() == typeof(IMapWith<>) — проверяет, является ли generic*ом интерфейс IMapWith<>

            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                    .Any(i=> i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList(); // Ищет все типы в сборке, которые реализуют интерфейс 

            // Activator.CreateInstance(type) — создает экземпляр типа с использованием рефлексии (создает экземпляр класса, описанного в type)
            // type.GetMethod("Mapping") - ищет метод Mapping
            // methodInfo?.Invoke(instance, new object[] { this }) — вызывает метод Mapping
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, [this]);
            }
        }
    }
}
