using System;

namespace Boruc.LabEquip.Services.SharedKernelES
{
	internal class UnregisteredDomainEventHandlerException : Exception
	{
		public UnregisteredDomainEventHandlerException(string message) : base(message) { }
	}
}