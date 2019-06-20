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

	/// <summary>
	/// Equipment controller possible actions:
	/// - get equipment list
	/// - get equipment item
	/// - create new equipment item
	/// </summary>
	[Route("api/v1/equipment")]
	[ApiController]
	public class EquipmentController : ControllerBase
	{
		private readonly IEquipmentQueries _equipmentQueries;
		private readonly ILogger<EquipmentController> _logger;
		private readonly IMediator _mediator;

		/// <summary>
		/// </summary>
		/// <param name="equipmentQueries"></param>
		/// <param name="logger"></param>
		/// <param name="mediator"></param>
		public EquipmentController(
			IEquipmentQueries equipmentQueries,
			ILogger<EquipmentController> logger,
			IMediator mediator)
		{
			_equipmentQueries = equipmentQueries ?? throw new ArgumentNullException(nameof(equipmentQueries));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
			_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		/// <summary>
		/// Retrieve list of all equipment items
		/// </summary>
		/// <response code="200">Returns list of equipment items</response>
		[Route("")]
		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<Equipment>), StatusCodes.Status200OK)]
		public async Task<ActionResult<IEnumerable<Equipment>>> GetEquipmentsAsync()
		{
			var equipments = await _equipmentQueries.GetEquipmentsAsync();
			return Ok(equipments);
		}

		/// <summary>
		/// Return equipment base on passed equipment id
		/// </summary>
		/// <param name="equipmentId">Equipment id</param>
		/// <response code="200">Returns an item</response>
		/// <response code="404">If id was not found</response>
		[Route("{equipmentId:int}")]
		[HttpGet]
		[ProducesResponseType(typeof(Equipment), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<Equipment>> GetEquipmentAsync(int equipmentId)
		{
			var equipment = await _equipmentQueries.GetEquipmentAsync(equipmentId);
			return Ok(equipment);
		}

		/// <summary>
		/// Create an equipment item.
		/// </summary>
		/// <remarks>
		///	Sample request:
		///
		///		POST/Equipment
		///		{
		///			"name": "Item1",
		///			"number": "123-1234-123"
		///		}
		/// 
		/// </remarks>
		/// <param name="createEquipmentCommand"></param>
		/// <response code="201">Item created with success</response>
		/// <response code="400">Item was not valid and was not created</response>
		[Route("")]
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AddNewEquipment([FromBody] CreateEquipmentCommand createEquipmentCommand)
		{
			_logger.LogInformation("Sending command: {CommandName} - {IdProperty}: ({@Command})",
				createEquipmentCommand.GetGenericTypeName(), nameof(createEquipmentCommand), createEquipmentCommand);

			await _mediator.Send(createEquipmentCommand);
			return StatusCode(StatusCodes.Status201Created);
		}

		/// <summary>
		/// Create new definition for maintenance task.
		/// </summary>
		/// <remarks>
		///	Sample request:
		///
		///		POST/action
		///		{
		///			"tasktype": "verification",
		///			"taskfrequency": "monthly",
		///			"firstoccurencedatetime": "2019-06-15T00:00:00.000"
		///		}
		/// 
		/// </remarks>
		/// <param name="addDefinitionOfActionCommand"></param>
		/// <response code="201">Action created with success</response>
		/// <response code="400">Action was not valid and was not created</response>
		[Route("{equipmentId:int}/action")] 
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AddNewDefinitionOfAction([FromBody] AddDefinitionOfActionCommand addDefinitionOfActionCommand)
		{
			_logger.LogInformation("Sending command: {CommandName} - {IdProperty}: ({@Command})",
				addDefinitionOfActionCommand.GetGenericTypeName(),
				nameof(addDefinitionOfActionCommand),
				addDefinitionOfActionCommand);

			 await _mediator.Send(addDefinitionOfActionCommand);
			 return StatusCode(StatusCodes.Status201Created);
		}
	}
}