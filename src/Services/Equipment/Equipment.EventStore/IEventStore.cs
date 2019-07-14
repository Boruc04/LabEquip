using System;
using System.Collections.Generic;
using Boruc.LabEquip.Services.SharedKernelES;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure.EventStore
{
	public interface IEventStore : IUnitOfWork
	{
		void SaveEvents(Guid aggregateId, IEnumerable<IEvent> events, int? expectedVersion);
		IList<IEvent> GetEventsForAggregate(Guid aggregateId);
	}
}
