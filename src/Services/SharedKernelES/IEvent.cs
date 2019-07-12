using MediatR;
using System;

namespace Boruc.LabEquip.Services.SharedKernelES
{
	public interface IEvent : INotification
	{
		Guid Id { get; }
		Guid AggregateId { get; }
		int Version { get; set; }
		DateTime EventCreationDateTimeUTC { get; }
	}
}