using MediatR;

namespace Classifiers.Application.Classifiers.Commands.Queries.GetClassifierDetails
{
    public class GetClassifierDetailsQuery : IRequest<ClassifierDetailsVm>
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string? Name { get; set; }
    }
}
