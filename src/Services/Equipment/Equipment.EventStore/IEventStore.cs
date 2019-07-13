using Boruc.LabEquip.Services.SharedKernelES;
using System;
using System.Collections.Generic;

namespace Boruc.LabEquip.Services.Equipment.EventStore
{
	public interface IEventStore : IUnitOfWork
	{
		void SaveEvents(Guid aggregateId, IEnumerable<IEvent> events, int? expectedVersion);
		IList<IEvent> GetEventsForAggregate(Guid aggregateId);
	}
}
