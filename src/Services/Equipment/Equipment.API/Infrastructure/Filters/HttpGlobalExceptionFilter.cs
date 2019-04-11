using Microsoft.AspNetCore.Mvc.Filters;

namespace Boruc.LabEquip.Services.Equipment.API.Infrastructure.Filters
{
	public class HttpGlobalExceptionFilter: IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			//TODO
			throw new System.NotImplementedException();
		}
	}
}
