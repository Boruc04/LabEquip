using System;
using System.Collections.Generic;

namespace SharedKernelES
{
	public abstract class AggregateRoot : IAggregateRoot
	{
		private readonly ICollection<Event> _events = new List<Event>();

		public abstract Guid Id { get; }
		public int Version { get; internal set; }

		void IAggregateRoot.ApplyChanges(Event @event)
		{
			ApplyChanges(@event);
		}

		public ICollection<Event> GetPendingEvents()
		{
			return _events;
		}

		public void ClearPendingEvents()
		{
			throw new NotImplementedException();
		}

		public void LoadFromHistory(IEnumerable<Event> history)
		{
			foreach (var @event in history)
			{
				ApplyChange(@event, false);
			}
		}

		protected void ApplyChanges(Event @event)
		{
			ApplyChange(@event, true);
		}

		private void ApplyChange(Event @event, bool b)
		{
			throw new NotImplementedException();
		}
	}

	public class Event { }
}
