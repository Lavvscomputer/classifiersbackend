using AutoMapper;
using Classifiers.Application.Classifiers.Commands.Queries.GetClassifierDetails;
using Classifiers.Application.Common.Mapping;
using Classifiers.Domain;

namespace Classifiers.Application.Classifiers.Commands.Queries.GetClassifierSection
{
    public class ClassifierSectionsVm : IMapWith<Classifier>
    {
        public List<ClassifierDetailsVm>? Classifiers { get; set; }

        public void Mapping(Profile profile) 
        {
            profile.CreateMap<Classifier, ClassifierDetailsVm>();
            profile.CreateMap<List<Classifier>, ClassifierSectionsVm>()
            .ForMember(dest => dest.Classifiers, opt => opt.MapFrom(src => src));
        }
    }
}
