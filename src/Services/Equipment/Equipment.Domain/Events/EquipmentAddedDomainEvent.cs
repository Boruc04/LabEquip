using MediatR;

namespace Boruc.LabEquip.Services.Equipment.Domain.Events
{
	using AggregatesModel.EquipmentAggregate;

	public class EquipmentAddedDomainEvent : INotification
	{
		public Equipment Equipment { get; }

		public EquipmentAddedDomainEvent(Equipment equipment)
		{
			Equipment = equipment;
		}
	}
}