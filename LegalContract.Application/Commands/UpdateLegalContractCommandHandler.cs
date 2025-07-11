using MediatR;

namespace LegalContract.Application.Commands
{
    public class UpdateLegalContractCommand : IRequest<Unit>
    {

    }

    internal class UpdateLegalContractCommandHandler : IRequestHandler<UpdateLegalContractCommand, Unit>
    {
        public Task<Unit> Handle(UpdateLegalContractCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
