using Boruc.LabEquip.Services.Equipment.Domain.EventsES;
using SharedKernelES;
using System;

namespace Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregateES
{
	public partial class Equipment2 : AggregateRoot
	{
		private string _name;
		private string _number;
		private DateTime _addedOnUTC;

		private Equipment2()
		{
			// Register internal event handlers
			registerInternalDomainEventHandlers();
		}

		public Equipment2(Guid id, string name, string number) : this()
		{
			ApplyChanges(new EquipmentCreatedEvent(id, name, number, DateTime.UtcNow));
		}
	}

	public partial class Equipment2
	{
		#region DomainEventHandlers

		private void registerInternalDomainEventHandlers()
		{
			RegisterEvent<EquipmentCreatedEvent>(OnNewEquipmentCreated);
		}

		private void OnNewEquipmentCreated(EquipmentCreatedEvent equipmentCreatedEvent)
		{
			Id = equipmentCreatedEvent.AggregateId;
			_name = equipmentCreatedEvent.Name;
			_number = equipmentCreatedEvent.Number;
			_addedOnUTC = equipmentCreatedEvent.AddedOnUTC;
		}

		#endregion
	}
}
