using AutoMapper;
using Classifiers.Application.Common.Exeptions;
using Classifiers.Application.Interfaces;
using Classifiers.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Classifiers.Application.Classifiers.Commands.Queries.GetClassifierDetails
{
    public class GetClassifierDetailsQueryHandler : IRequestHandler<GetClassifierDetailsQuery, ClassifierDetailsVm>
    {
        private readonly IClassifiersDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetClassifierDetailsQueryHandler(IClassifiersDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ClassifierDetailsVm> Handle(GetClassifierDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Classifiers
                .FirstOrDefaultAsync(cls => cls.Id == request.Id, cancellationToken) 
                    ?? throw new NotFoundException(nameof(Classifier), request.Id);

            return _mapper.Map<ClassifierDetailsVm>(entity);
        }
    }
}
