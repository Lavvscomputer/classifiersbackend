using AutoMapper;
using Classifiers.Application.Common.Mapping;
using Classifiers.Domain;

namespace Classifiers.Application.Classifiers.Commands.Queries.GetClassifierDetails
{
    public class ClassifierDetailsVm : IMapWith<Classifier>
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string? Name { get; set; }

        public void Mapping(Profile profile) 
        {
            profile.CreateMap<Classifier, ClassifierDetailsVm>()
                .ForMember(clsVm => clsVm.Id, opt =>
                    opt.MapFrom(classifier => classifier.Id))
                .ForMember(clsVm => clsVm.ParentId, opt =>
                    opt.MapFrom(classifier => classifier.ParentId))
                .ForMember(clsVm => clsVm.Name, opt =>
                    opt.MapFrom(classifier => classifier.Name));
        }
    }
}
