using MediatR;

namespace Classifiers.Application.Classifiers.Commands.CreateClassifier
{
    public class CreateClassifierCommand : IRequest<int>
    {
        public int? ParentId { get; set; }
        public string? Name { get; set; }
    }
}
