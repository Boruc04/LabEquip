using Boruc.LabEquip.Services.Equipment.Application.Commands;
using Boruc.LabEquip.Services.GenericExtensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.API.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[Route("api/v1/equipment")]
	[ApiController]
	public class ActionController : CustomBaseController
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="mediator"></param>
		/// <param name="logger"></param>
		public ActionController(IMediator mediator, ILogger<CustomBaseController> logger) : base(mediator, logger) { }

		///   <summary>
		///   Create new definition for maintenance task.
		///   </summary>
		///   <remarks>
		///  	Sample request:
		///  
		///  		POST/action
		///  		{
		/// 			"tasktype": "verification",
		///  			"taskfrequency": "monthly",
		///  			"firstoccurencedatetime": "2019-06-15T00:00:00.000"
		///  		}
		///   
		///   </remarks>
		///   <param name="equipmentId"></param>
		///   <param name="createActionTypeCommand"></param>
		///   <response code="201">Action created with success</response>
		///   <response code="400">Action was not valid and was not created</response>
		[Route("{equipmentId:int}/action")]
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CreateActionType(int equipmentId, [FromBody] CreateActionTypeCommand createActionTypeCommand)
		{
			createActionTypeCommand.AddEquipmentId(equipmentId); // This is compromise on REST and CQRS - TODO: research if there are better ways to handle that.
			Logger.LogInformation("Sending command: {CommandName} - {IdProperty}: ({@Command})",
				createActionTypeCommand.GetGenericTypeName(),
				nameof(createActionTypeCommand),
				createActionTypeCommand);

			var commandResult = await Mediator.Send(createActionTypeCommand);

			if (!commandResult)
			{
				return BadRequest();
			}

			return StatusCode(StatusCodes.Status201Created);
		}
	}
}