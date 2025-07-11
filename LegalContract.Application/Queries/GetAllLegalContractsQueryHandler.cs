using MediatR;

namespace LegalContract.Application.Queries
{
    public class GetAllLegalContractsQuery : IRequest<List<Domain.Entities.LegalContract>>
    {

    }

    public class GetAllLegalContractsQueryHandler : IRequestHandler<GetAllLegalContractsQuery, List<Domain.Entities.LegalContract>>
    {
        public Task<List<Domain.Entities.LegalContract>> Handle(GetAllLegalContractsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
