using Microsoft.AspNetCore.Mvc;
using Moq;
using Optimus.AtHomeBestOffer.Application.Model;
using Optimus.AtHomeBestOffer.Application.Service;
using Optimus.AtHomeBestOffer.Host.Controllers;

namespace Optimus.AtHomeBestOffer.UnitTest.ControllerTests
{
    public class BestOfferControllerTests
    {
        private readonly Mock<IOfferProcessService> _mockOfferProcessService;
        private readonly BestOfferController _controller;

        public BestOfferControllerTests()
        {
            _mockOfferProcessService = new Mock<IOfferProcessService>();
            _controller = new BestOfferController(_mockOfferProcessService.Object);
        }

        [Fact]
        public void Should_Return_ProposedOffer()
        {
            var order = new Order()
            {
                SourceAddress = "Optimus Source Address1",
                DestinationAddress = "Optimus Destination Address1",
                CartonDimensions = new List<Dimensions>
                                {
                                    new Dimensions
                                    {
                                        Length = 10,
                                        Width = 10,
                                        Height = 10,
                                    },
                                    new Dimensions
                                    {
                                        Length = 10,
                                        Width = 10,
                                        Height = 10,
                                    }
                                }
            };

            _mockOfferProcessService.Setup(repo => repo.Process(order))
                .Returns(new List<ProposedOffer>()
                {
                    new ProposedOffer(){
                        CompanyName = "Company 1",
                        Total = 120
                    }
                });

            var result = _controller.GetOffer(order);
            var response = Assert.IsType<ActionResult<IEnumerable<ProposedOffer>>>(result);
            var bestOffer = (IEnumerable<ProposedOffer>)(response.Result as OkObjectResult).Value;
            Assert.Equal("Company 11", bestOffer.ToList()[0].CompanyName);
            Assert.Equal(120, bestOffer.ToList()[0].Total);
        }
    }
}