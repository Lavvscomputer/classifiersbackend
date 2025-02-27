using MediatR;
using Classifiers.Domain;
using Classifiers.Application.Interfaces;

namespace Classifiers.Application.Classifiers.Commands.CreateClassifier
{
    public class CreateClassifierCommandHandler(IClassifiersDbContext dbContext) : IRequestHandler<CreateClassifierCommand, int>
    {
        private readonly IClassifiersDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<int> Handle(CreateClassifierCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var classifier = new Classifier
            {
                ParentId = request.ParentId,
                Name = request.Name,
            };

            try
            {
                await _dbContext.Classifiers.AddAsync(classifier, cancellationToken);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return classifier.Id;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ошибка при создании классификатора", ex);
            }
        }
    }
}
