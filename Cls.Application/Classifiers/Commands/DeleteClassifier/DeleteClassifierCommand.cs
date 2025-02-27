using MediatR;

namespace Classifiers.Application.Classifiers.Commands.DeleteClassifier
{
    public class DeleteClassifierCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
