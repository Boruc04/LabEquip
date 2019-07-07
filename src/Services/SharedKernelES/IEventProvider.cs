using System;
using System.Collections.Generic;

namespace SharedKernelES
{
	public interface IEventProvider<TEvent> where TEvent : IEvent
	{
		Guid Id { get; }
		int Version { get; }
		IEnumerable<TEvent> GetPendingEvents();
		void ClearPendingEvents();
		void LoadFromHistory(IEnumerable<TEvent> historicalEvents);
	}
}
