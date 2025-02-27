using MediatR;

namespace Classifiers.Application.Classifiers.Commands.UpdateClassifier
{
    public class UpdateClassifierCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string? Name { get; set; }
    }
}
