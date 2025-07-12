using LegalContract.Application.Commands;
using LegalContract.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LegalContract.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegalContractController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LegalContractController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {

            try
            {
                await _mediator.Send(new GetAllLegalContractsQuery());

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateLegalContract()
        {
            try
            {
                var legalContract = new CreateLegalContractCommand();

                await _mediator.Send(legalContract);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLegalContract()
        {
            try
            {
                var legalContract = new UpdateLegalContractCommand();

                await _mediator.Send(legalContract);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLegalContract(string id)
        {
            try
            {
                var legalContract = new DeleteLegalContractCommand
                {
                    Id = id
                };

                await _mediator.Send(legalContract);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
