using Classifiers.Application.Classifiers.Commands.Queries.GetClassifierSection;
using MediatR;

namespace Classifiers.Application.Classifiers.Commands.Queries.GetClassifierSection
{
    public class GetClassifierSectionQuery : IRequest<ClassifierSectionsVm>
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string? Name { get; set; }
    }
}
