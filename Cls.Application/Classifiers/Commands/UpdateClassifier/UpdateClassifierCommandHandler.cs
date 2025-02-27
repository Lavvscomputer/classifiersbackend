using MediatR;
using Classifiers.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Classifiers.Application.Common.Exeptions;
using Classifiers.Domain;

namespace Classifiers.Application.Classifiers.Commands.UpdateClassifier
{
    public class UpdateClassifierCommandHandler : IRequestHandler<UpdateClassifierCommand, int>
    {
        private readonly IClassifiersDbContext _dbContext;

        public UpdateClassifierCommandHandler(IClassifiersDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<int> Handle(UpdateClassifierCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Classifiers
                .FirstOrDefaultAsync(cls => cls.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Classifier), request.Id);

            entity.ParentId = request.ParentId;
            entity.Name = request.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}