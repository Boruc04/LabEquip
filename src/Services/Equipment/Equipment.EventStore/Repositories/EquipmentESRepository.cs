using System;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure.EventStore.Repositories
{
	using Domain.AggregatesModel.EquipmentAggregateES;
	using SharedKernelES;

	public class EquipmentESRepository : IEquipmentESRepository
	{
		private readonly IEventStore _eventStore;
		public IUnitOfWork UnitOfWork => _eventStore;

		public EquipmentESRepository(IEventStore eventStore)
		{
			_eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
		}

		public void Add(EquipmentES aggregateRoot, int expectedVersion)
		{
			_eventStore.SaveEvents(aggregateRoot.Id, aggregateRoot.GetPendingEvents(), aggregateRoot.Version);
		}

		public EquipmentES GetById(Guid id)
		{
			var equipment = new EquipmentES();
			var events = _eventStore.GetEventsForAggregate(id);
			equipment.LoadFromHistory(events);
			return equipment;
		}
	}
}
