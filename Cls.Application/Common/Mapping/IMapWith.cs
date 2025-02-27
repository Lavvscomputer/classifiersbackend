using AutoMapper;

namespace Classifiers.Application.Common.Mapping
{
    public interface IMapWith<T>
    {

        //CreateMap - метод AutoMapper создает маппинг между двумя типами
        //typeof(T) — с которым нужно сопоставить текущий объект.
        //GetType() — тип текущего интерфейса
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}
