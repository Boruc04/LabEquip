using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Boruc.LabEquip.Services.Equipment.API.Controllers
{
	/// <summary>
	/// Custom controller implementation that will provide Mediator and Logger.
	/// </summary>
	[ApiController]
	public abstract class CustomBaseController : ControllerBase
	{
		/// <summary>
		/// Mediator that will handle communication between commands and handlers.
		/// </summary>
		protected readonly IMediator Mediator;
		/// <summary>
		/// Interface that is providing Logging functionality.
		/// </summary>
		protected readonly ILogger<CustomBaseController> Logger;

		/// <summary>
		/// Base constructor for controller.
		/// </summary>
		/// <param name="mediator"></param>
		/// <param name="logger"></param>
		protected CustomBaseController(IMediator mediator, ILogger<CustomBaseController> logger)
		{
			Logger = logger ?? throw new ArgumentNullException(nameof(logger));
			Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}
	}
}