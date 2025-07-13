using LegalContract.Persistence;
using MediatR;

namespace LegalContract.Application.Commands
{
    public class CreateLegalContractCommand : IRequest<Unit>
    {
        public string Author { get; set; }

        public string EntityName { get; set; }

        public string Description { get; set; }
    }

    public class CreateLegalContractCommandHandler : IRequestHandler<CreateLegalContractCommand, Unit>
    {
        private readonly LegalContractDbContext _ctx;

        public CreateLegalContractCommandHandler(LegalContractDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Unit> Handle(CreateLegalContractCommand request, CancellationToken cancellationToken)
        {
            try
            {

                await _ctx.Contract.AddAsync(new Domain.Entities.Contract
                {
                    Author = request.Author,
                    EntityName = request.EntityName,
                    Description = request.Description
                });

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
