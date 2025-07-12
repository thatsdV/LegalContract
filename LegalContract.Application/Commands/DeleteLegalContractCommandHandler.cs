using LegalContract.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LegalContract.Application.Commands
{
    public class DeleteLegalContractCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

    public class DeleteLegalContractCommandHandler : IRequestHandler<DeleteLegalContractCommand, Unit>
    {
        private readonly LegalContractDbContext _ctx;

        public DeleteLegalContractCommandHandler(LegalContractDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Unit> Handle(DeleteLegalContractCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _ctx.Contract.Remove(new Domain.Entities.Contract { Id =  request.Id });

                await _ctx.SaveChangesAsync();

                return Unit.Value;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
