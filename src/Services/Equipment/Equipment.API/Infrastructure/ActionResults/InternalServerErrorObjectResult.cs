using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Boruc.LabEquip.Services.Equipment.API.Infrastructure.ActionResults
{
	public class InternalServerErrorObjectResult : ObjectResult
	{
		public InternalServerErrorObjectResult(object error) : base(error)
		{
			StatusCode = StatusCodes.Status500InternalServerError;
		}
	}
}