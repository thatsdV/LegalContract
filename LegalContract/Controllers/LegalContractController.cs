using LegalContract.Application.Commands;
using LegalContract.Application.Models;
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
                var legalContracts = await _mediator.Send(new GetAllLegalContractsQuery());

                return Ok(legalContracts);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateLegalContract(CreateLegalContractRequest request)
        {
            try
            {
                var legalContract = new CreateLegalContractCommand
                {
                    Author = request.Author,
                    Description = request.Description,
                    EntityName = request.EntityName
                };

                await _mediator.Send(legalContract);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLegalContract(UpdateLegalContractRequest request)
        {
            try
            {
                var legalContract = new UpdateLegalContractCommand
                {
                    Id = request.Id,
                    Author = request.Author,
                    Description = request.Description,
                    EntityName = request.EntityName
                };

                await _mediator.Send(legalContract);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLegalContract(int id)
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
