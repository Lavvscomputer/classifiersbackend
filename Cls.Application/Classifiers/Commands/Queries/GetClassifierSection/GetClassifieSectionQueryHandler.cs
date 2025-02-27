using AutoMapper;
using Classifiers.Application.Common.Exeptions;
using Classifiers.Application.Interfaces;
using Classifiers.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Classifiers.Application.Classifiers.Commands.Queries.GetClassifierSection
{
    public class GetClassifierSectionQueryHandler : IRequestHandler<GetClassifierSectionQuery, ClassifierSectionsVm>
    {
        private readonly IClassifiersDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetClassifierSectionQueryHandler(IClassifiersDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ClassifierSectionsVm> Handle(GetClassifierSectionQuery request, CancellationToken cancellationToken)
        {
            var classifiers = await _dbContext.Classifiers
             .Where(c => c.ParentId == request.ParentId)
             .ToListAsync(cancellationToken);

            if (classifiers == null || classifiers.Count == 0)
            {
                throw new NotFoundException(nameof(Classifier), request.ParentId);
            }

            // Маппинг списка сущностей в ClassifierSectionsVm
            return _mapper.Map<ClassifierSectionsVm>(classifiers);
        }
    }
}
