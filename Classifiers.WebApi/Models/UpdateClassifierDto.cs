using AutoMapper;
using Classifiers.Application.Classifiers.Commands.CreateClassifier;
using Classifiers.Application.Classifiers.Commands.UpdateClassifier;
using Classifiers.Application.Common.Mapping;

namespace Classifiers.WebApi.Models
{
    public class UpdateClassifierDto : IMapWith<UpdateClassifierDto>
    {
        public int? Id { get; set; }
        public int ParentId{ get; set; }
        public string? Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateClassifierDto, UpdateClassifierCommand>()
                .ForMember(clsCommand => clsCommand.Id,
                    opt => opt.MapFrom(clsDto => clsDto.Id))
                .ForMember(clsCommand => clsCommand.ParentId,
                    opt => opt.MapFrom(clsDto => clsDto.ParentId))
                .ForMember(clsCommand => clsCommand.Name,
                    opt => opt.MapFrom(clsDto => clsDto.Name));
        }
    }
}
