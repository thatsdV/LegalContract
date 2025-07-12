using LegalContract.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LegalContract.Application.Commands
{
    public class UpdateLegalContractCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string EntityName { get; set; }

        public string Description { get; set; }
    }

    public class UpdateLegalContractCommandHandler : IRequestHandler<UpdateLegalContractCommand, Unit>
    {
        private readonly LegalContractDbContext _ctx;

        public UpdateLegalContractCommandHandler(LegalContractDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Unit> Handle(UpdateLegalContractCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var contract = _ctx.Contract.FirstOrDefault(e => e.Id == request.Id);

                if (contract != null)
                {
                    contract.Author = request.Author;
                    contract.Description = request.Description;
                    contract.EntityName = request.EntityName;

                    await _ctx.SaveChangesAsync();
                }

                return Unit.Value;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
