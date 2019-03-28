using Boruc.LabEquip.Services.Equipping.Domain.AggregatesModel.EquipmentAggregates;
using MediatR;

namespace Boruc.LabEquip.Services.Equipping.Domain.Events
{
	public class EquipmentAddedDomainEvent : INotification
	{
		public Equipment Equipment { get; }

		public EquipmentAddedDomainEvent(Equipment equipment)
		{
			Equipment = equipment;
		}
	}
}