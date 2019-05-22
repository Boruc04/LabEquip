using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.API.Controllers
{
	using Application.Commands;
	using Application.Queries;
	using Extensions;
	using MediatR;

	[Route("api/v1/[controller]")]
	[ApiController]
	public class EquipmentController : ControllerBase
	{
		private readonly IEquipmentQueries _equipmentQueries;
		private readonly ILogger<EquipmentController> _logger;
		private readonly IMediator _mediator;

		public EquipmentController(
			IEquipmentQueries equipmentQueries,
			ILogger<EquipmentController> logger,
			IMediator mediator)
		{
			_equipmentQueries = equipmentQueries;
			_logger = logger;
			_mediator = mediator;
		}

		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<Equipment>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<Equipment>>> GetEquipmentsAsync()
		{
			var equipments = await _equipmentQueries.GetEquipmentsAsync();
			return Ok(equipments);
		}

		//[HttpPost]
		//[ProducesResponseType(typeof())]
		//public async Task<ActionResult> CreateEquipment([FromBody] CreateEquipmentCommand createEquipmentCommand)
		//{
		//	_logger.LogInformation("Sending command: {CommandName} - {IdProperty}: ({@Command})", 
		//		createEquipmentCommand.GetGenericTypeName(), nameof(createEquipmentCommand), createEquipmentCommand);

		//	await _mediator.Send(createEquipmentCommand);
		//	return Created();
		//}
	}
}