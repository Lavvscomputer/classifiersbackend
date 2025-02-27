using AutoMapper;
using Classifiers.Application.Classifiers.Commands.CreateClassifier;
using Classifiers.Application.Common.Mapping;

namespace Classifiers.WebApi.Models
{
    public class CreateClassifierDto : IMapWith<CreateClassifierCommand>
    {
        public int? ParentId { get; set; }
        public string? Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateClassifierDto, CreateClassifierCommand>()
                .ForMember(clsCommand => clsCommand.Name,
                    opt => opt.MapFrom(clsDto => clsDto.Name))
                .ForMember(clsCommand => clsCommand.ParentId,
                    opt => opt.MapFrom(clsDto => clsDto.ParentId));
        }
    }
}
