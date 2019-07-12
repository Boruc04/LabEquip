using Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregateES;
using Boruc.LabEquip.Services.SharedKernelES;
using System;

namespace Boruc.LabEquip.Services.Equipment.EventStore.Repositories
{
	public class EquipmentRepository : IEquipmentRepositoryES
	{
		private readonly IEventStore _eventStore;
		public IUnitOfWork UnitOfWork => _eventStore;

		public EquipmentRepository(IEventStore eventStore)
		{
			_eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
		}

		public void Add(Equipment2 aggregateRoot, int expectedVersion)
		{
			_eventStore.SaveEvents(aggregateRoot.Id, aggregateRoot.GetPendingEvents(), aggregateRoot.Version);
		}

		public Equipment2 GetById(Guid id)
		{

			var events = _eventStore.GetEventsForAggregate(id);
			return null;
		}
	}
}
