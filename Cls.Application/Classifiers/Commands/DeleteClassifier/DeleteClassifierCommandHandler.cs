using Classifiers.Application.Common.Exeptions;
using Classifiers.Application.Interfaces;
using Classifiers.Domain;
using MediatR;

namespace Classifiers.Application.Classifiers.Commands.DeleteClassifier
{
    public class DeleteClassifierCommandHandler(IClassifiersDbContext? dbContext) : IRequestHandler<DeleteClassifierCommand, int>
    {
        private readonly IClassifiersDbContext? _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<int> Handle(DeleteClassifierCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Classifiers.FindAsync([request.Id, cancellationToken], cancellationToken: cancellationToken)
                         ?? throw new NotFoundException(nameof(Classifier), request.Id);

            _dbContext.Classifiers.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
