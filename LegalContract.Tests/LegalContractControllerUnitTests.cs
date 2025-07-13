using LegalContract.Application.Commands;
using LegalContract.Application.Models;
using LegalContract.Application.Queries;
using LegalContract.Controllers;
using LegalContract.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Text.Json;

namespace LegalContract.Tests
{
    [TestFixture]
    public class LegalContractTests
    {
        private Mock<IMediator> _mediatorMock;
        private LegalContractController _controller;

        [SetUp]
        public void Setup()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new LegalContractController(_mediatorMock.Object);
        }

        [Test]
        public async Task GetAll_ReturnsOkResult_WithContracts()
        {
            var contracts =  new List<Domain.Entities.Contract>
            {
                new() { Id = 1, Author = "Author1", EntityName = "Entity1", Description = "Description1" },
                new() { Id = 2, Author = "Author2", EntityName = "Entity2", Description = "Description2" }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllLegalContractsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(contracts);

            var result = await _controller.GetAll();

            var resultValue = (result as OkObjectResult).Value;

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            Assert.That(resultValue, Is.EqualTo(contracts));
        }

        [Test]
        public async Task CreateLegalContract_ReturnsOkResult()
        {
            var request = new CreateLegalContractRequest
            {
                Author = "Author",
                Description = "Description",
                EntityName = "Entity"
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateLegalContractCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(Unit.Value);

            var result = await _controller.CreateLegalContract(request);

            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        public async Task UpdateLegalContract_ReturnsOkResult()
        {
            var request = new UpdateLegalContractRequest
            {
                Id = 1,
                Author = "Author",
                Description = "Description",
                EntityName = "Entity"
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<UpdateLegalContractCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Unit.Value);

            var result = await _controller.UpdateLegalContract(request);

            Assert.That(result, Is.InstanceOf<OkResult>());
        }

        [Test]
        public async Task DeleteLegalContract_ReturnsOkResult()
        {
            int id = 1;
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<DeleteLegalContractCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Unit.Value);

            var result = await _controller.DeleteLegalContract(id);

            Assert.That(result, Is.InstanceOf<OkResult>());
        }
    }
}