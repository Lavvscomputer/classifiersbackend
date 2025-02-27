using MediatR;
namespace Classifiers.Application.Classifiers.Commands.Queries.GetClassifierList
{
    public class GetClassifierListQuery : IRequest<ClassifierListVm>
    {
        public int Id { get; set; }
    }
}
