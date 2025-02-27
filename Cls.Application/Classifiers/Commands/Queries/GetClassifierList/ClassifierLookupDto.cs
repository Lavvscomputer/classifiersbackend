using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Classifiers.Application.Common.Mapping;
using Classifiers.Domain;

namespace Classifiers.Application.Classifiers.Commands.Queries.GetClassifierList
{
    public class ClassifierLookupDto : IMapWith<Classifier>
    {
        public int Id { get; set; }      
        public int? ParentId { get; set; }      
        public string? Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Classifier, ClassifierLookupDto>()
                .ForMember(clsDto => clsDto.Id,
                    opt => opt.MapFrom(cls => cls.Id))
                .ForMember(clsDto => clsDto.ParentId,
                    opt => opt.MapFrom(cls => cls.ParentId))
                .ForMember(clsDto => clsDto.Name,
                    opt => opt.MapFrom(cls => cls.Name));
        }
    }
}
