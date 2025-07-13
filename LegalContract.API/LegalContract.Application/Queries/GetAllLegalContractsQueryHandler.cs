using LegalContract.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LegalContract.Application.Queries
{
    public class GetAllLegalContractsQuery : IRequest<List<Domain.Entities.Contract>>
    {
    }

    public class GetAllLegalContractsQueryHandler : IRequestHandler<GetAllLegalContractsQuery, List<Domain.Entities.Contract>>
    {
        private readonly LegalContractDbContext _ctx;

        public GetAllLegalContractsQueryHandler(LegalContractDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Domain.Entities.Contract>> Handle(GetAllLegalContractsQuery request, CancellationToken cancellationToken)
        {
            var legalContracts = await _ctx.Contract.ToListAsync();

            return legalContracts;
        }
    }
}
