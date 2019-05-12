using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.API.Controllers
{
	using Application.Queries;

	[Route("api/v1/[controller]")]
	[ApiController]
	public class EquipmentController : ControllerBase
	{
		private readonly IEquipmentQueries _equipmentQueries;
		private readonly ILogger<EquipmentController> _logger;

		public EquipmentController(IEquipmentQueries equipmentQueries,
			ILogger<EquipmentController> logger)
		{
			_equipmentQueries = equipmentQueries;
			_logger = logger;
		}

		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<Equipment>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<Equipment>>> GetEquipmentsAsync()
		{
			var equipments = await _equipmentQueries.GetEquipmentsAsync();
			return Ok(equipments);
		}
	}
}