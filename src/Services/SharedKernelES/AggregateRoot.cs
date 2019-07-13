using System;
using System.Collections.Generic;

namespace Boruc.LabEquip.Services.SharedKernelES
{
	public abstract class AggregateRoot : IEventProvider<IEvent>
	{
		private readonly List<IEvent> _domainEvents;
		private readonly Dictionary<Type, Action<IEvent>> _registeredDomainEventHandlersActions;

		public Guid Id { get; protected set; }
		public int Version { get; protected set; }

		protected AggregateRoot()
		{
			_registeredDomainEventHandlersActions = new Dictionary<Type, Action<IEvent>>();
			_domainEvents = new List<IEvent>();
		}

		public IEnumerable<IEvent> GetPendingEvents()
		{
			return _domainEvents;
		}

		public void ClearPendingEvents()
		{
			_domainEvents.Clear();
		}

		void IEventProvider<IEvent>.LoadFromHistory(IEnumerable<IEvent> historicalEvents)
		{
			foreach (var @event in historicalEvents)
			{
				ApplyEvent(@event);
			}
		}

		protected void ApplyChanges(Event @event)
		{
			ApplyEvent(@event);
			_domainEvents.Add(@event);
		}

		private void ApplyEvent(IEvent @event)
		{
			if (!_registeredDomainEventHandlersActions.TryGetValue(@event.GetType(), out var handler))
			{
				throw new UnregisteredDomainEventHandlerException(
					$"Requested domain event [{@event.GetType().FullName}], is not registered in [{GetType().FullName}]");
			}

			handler(@event);
		}

		protected  void RegisterEvent<TEvent>(Action<TEvent> eventHandler) where TEvent : class, IEvent
		{
			_registeredDomainEventHandlersActions.Add(typeof(TEvent), theEvent => eventHandler(theEvent as TEvent));
		}
	}
}
