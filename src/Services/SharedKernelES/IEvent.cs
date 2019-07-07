using System;
using MediatR;

namespace SharedKernelES
{
	public interface IEvent : INotification
	{
		Guid Id { get; }
		int Version { get; set; }
	}
}