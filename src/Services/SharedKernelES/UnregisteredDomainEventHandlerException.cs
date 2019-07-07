using System;

namespace SharedKernelES
{
	internal class UnregisteredDomainEventHandlerException : Exception
	{
		public UnregisteredDomainEventHandlerException(string message) : base(message) { }
	}
}