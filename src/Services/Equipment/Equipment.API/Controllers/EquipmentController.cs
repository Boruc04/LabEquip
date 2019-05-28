using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.API.Controllers
{
	using Application.Commands;
	using Application.Queries;
	using GenericExtensions;

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
			_equipmentQueries = equipmentQueries ?? throw new ArgumentNullException(nameof(equipmentQueries));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
			_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		[Route("")]
		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<Equipment>), StatusCodes.Status200OK)]
		public async Task<ActionResult<IEnumerable<Equipment>>> GetEquipmentsAsync()
		{
			var equipments = await _equipmentQueries.GetEquipmentsAsync();
			return Ok(equipments);
		}

		[Route("{equipmentId:int}")]
		[HttpGet]
		[ProducesResponseType(typeof(Equipment), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<Equipment>> GetEquipmentAsync(int equipmentId)
		{
			var equipment = await _equipmentQueries.GetEquipmentAsync(equipmentId);

			return Ok(equipment);
		}

		[Route("")]
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CreateEquipment([FromBody] CreateEquipmentCommand createEquipmentCommand)
		{
			_logger.LogInformation("Sending command: {CommandName} - {IdProperty}: ({@Command})",
				createEquipmentCommand.GetGenericTypeName(), nameof(createEquipmentCommand), createEquipmentCommand);

			await _mediator.Send(createEquipmentCommand);

			return StatusCode(StatusCodes.Status201Created);
		}
	}
}