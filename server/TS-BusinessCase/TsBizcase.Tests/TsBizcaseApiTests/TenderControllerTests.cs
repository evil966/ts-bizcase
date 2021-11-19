using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TsBizcase.Api.Controllers;
using TsBizcase.Application.Factories;
using TsBizcase.Application.Model;
using TsBizcase.Application.Queries;
using TsBizcase.Application.Responses;
using Xunit;

namespace TsBizcase.UnitTests.TsBizcaseApiTests
{
    public class TenderControllerTests
    {
        [Fact]
        public async Task TenderGetAll_WithNoParameters_ReturnsIQueryableOfTenderRecords()
        {
            // Arrange
            var record = new TenderRecord
            {
                Id = 1,
                Name = "Dummy",
                ReferenceNumber = "12345",
                ReleaseDate = DateTime.Now.Date,
                ClosingDate = DateTime.Now.Date,
                Description = "Dummy",
                CreatorId = 1
            };

            var dummyData = new List<TenderRecord> { record };
            var tenderQueryResponse = new TenderQueryResponse(dummyData);
            
            var mediatorStub = new Mock<IMediator>();
            var queryMakerStub = new Mock<IQueryMaker>();

            queryMakerStub.Setup(command => command.GetAllTendersQuery())
                .Returns(new GetAllTendersQuery());

            mediatorStub.Setup(m => m.Send(It.IsAny<GetAllTendersQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(tenderQueryResponse);

            Mock<TenderQueryResponse> response = new();
            response.SetupProperty(p => p.Record, dummyData.AsEnumerable());

            var tenderController = new TenderController(mediatorStub.Object, queryMakerStub.Object);

            // Act
            var result = await tenderController.GetAll();

            // Assert
            Assert.NotNull(result);
        }
    }
}
