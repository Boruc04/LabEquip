using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Boruc.LabEquip.Services.Equipment.API.Application.Queries;

namespace Boruc.LabEquip.Services.Equipment.API.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class EquipmentController : ControllerBase
	{
		private readonly IEquipmentQueries _equipmentQueries;

		public EquipmentController(IEquipmentQueries equipmentQueries)
		{
			_equipmentQueries = equipmentQueries;
		}


		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<Application.Queries.Equipment>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<Application.Queries.Equipment>>> GetEquipmentsAsync()
		{
			var equipments = await _equipmentQueries.GetEquipmentAsync();
			return Ok(equipments);
		}
	}
}