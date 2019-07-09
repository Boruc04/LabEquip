using SharedKernelES;
using System;

namespace Boruc.LabEquip.Services.Equipment.Domain.EventsES
{
	public class EquipmentCreatedEvent : Event
	{
		public string Name { get; private set; }
		public string Number { get; private set; }
		public DateTime AddedOnUTC { get; private set; }

		public EquipmentCreatedEvent(Guid aggregateId, string name, string number, DateTime addedOnUTC)
		{
			AggregateId = aggregateId;
			Name = name;
			Number = number;
			AddedOnUTC = addedOnUTC;
		}

	}
}