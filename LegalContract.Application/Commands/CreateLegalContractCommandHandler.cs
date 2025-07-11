using MediatR;

namespace LegalContract.Application.Commands
{
    public class CreateLegalContractCommand : IRequest<Unit>
    {

    }

    public class CreateLegalContractCommandHandler : IRequestHandler<CreateLegalContractCommand, Unit>
    {
        public Task<Unit> Handle(CreateLegalContractCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
