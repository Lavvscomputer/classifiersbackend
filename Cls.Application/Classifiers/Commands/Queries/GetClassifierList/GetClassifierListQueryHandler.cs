using AutoMapper;
using MediatR;
using Classifiers.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Classifiers.Application.Classifiers.Commands.Queries.GetClassifierList
{
    public class GetClassifierListQueryHandler : IRequestHandler<GetClassifierListQuery, ClassifierListVm>
    {
        private readonly IClassifiersDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetClassifierListQueryHandler(IClassifiersDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ClassifierListVm> Handle(GetClassifierListQuery request, CancellationToken cancellationToken)
        {
            var clsQuery = await _dbContext.Classifiers
                .ProjectTo<ClassifierLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ClassifierListVm { Classifiers = clsQuery };
        }
    }
}
