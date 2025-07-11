using MediatR;

namespace LegalContract.Application.Commands
{
    public class DeleteLegalContractCommand : IRequest<Unit>
    {
        public required string Id { get; set; }
    }

    public class DeleteLegalContractCommandHandler : IRequestHandler<DeleteLegalContractCommand, Unit>
    {
        public Task<Unit> Handle(DeleteLegalContractCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
