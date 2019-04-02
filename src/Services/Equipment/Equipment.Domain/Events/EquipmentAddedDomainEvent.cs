using MediatR;

namespace Boruc.LabEquip.Services.Equipment.Domain.Events
{
	public class EquipmentAddedDomainEvent : INotification
	{
		public AggregatesModel.EquipmentAggregates.Equipment Equipment { get; }

		public EquipmentAddedDomainEvent(AggregatesModel.EquipmentAggregates.Equipment equipment)
		{
			Equipment = equipment;
		}
	}
}