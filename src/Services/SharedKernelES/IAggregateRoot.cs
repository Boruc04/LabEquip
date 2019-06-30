using System;
using System.Collections.Generic;

namespace SharedKernelES
{
	interface IAggregateRoot
	{
		int Version { get; }
		Guid Id { get; }
		void ApplyChanges(Event @event);
		ICollection<Event> GetPendingEvents();
		void ClearPendingEvents();
	}
}
