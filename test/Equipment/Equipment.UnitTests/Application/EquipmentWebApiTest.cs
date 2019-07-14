using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Boruc.LabEquip.Equipment.UnitTests.Application
{
	using MediatR;
	using Services.Equipment.API.Controllers;
	using Services.Equipment.Application.Queries;

	public class EquipmentWebApiTest
	{
		private readonly Mock<IEquipmentQueries> _equipmentQueriesMock;
		private readonly Mock<ILogger<EquipmentController>> _loggerMock;
		private readonly Mock<IMediator> _mediator;

		public EquipmentWebApiTest()
		{
			_loggerMock = new Mock<ILogger<EquipmentController>>();
			_equipmentQueriesMock = new Mock<IEquipmentQueries>();
			_mediator = new Mock<IMediator>();
		}

		[Fact]
		public async Task GetEquipments_Success()
		{
			var fakeDynamicResult = Enumerable.Empty<EquipmentViewModel>();
			_equipmentQueriesMock.Setup(queries => queries.GetEquipmentsAsync())
				.Returns(Task.FromResult(fakeDynamicResult));

			var equipmentController = new EquipmentController(_equipmentQueriesMock.Object, _loggerMock.Object, _mediator.Object);
			var actionResult = await equipmentController.GetEquipmentsAsync();

			Assert.Equal((actionResult.Result as OkObjectResult)?.StatusCode, StatusCodes.Status200OK);
		}
	}
}
