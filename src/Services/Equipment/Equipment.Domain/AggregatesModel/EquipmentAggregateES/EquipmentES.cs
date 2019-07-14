using Boruc.LabEquip.Services.Equipment.Domain.EventsES;
using Boruc.LabEquip.Services.SharedKernelES;
using System;

namespace Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregateES
{
	public partial class EquipmentES : AggregateRoot
	{
		private string _name;
		private string _number;
		private DateTime _addedOnUTC;

		public EquipmentES()
		{
			// Register internal event handlers
			registerInternalDomainEventHandlers();
		}

		public EquipmentES(Guid id, string name, string number) : this()
		{
			ApplyChanges(new EquipmentCreatedEvent(id, name, number, DateTime.UtcNow));
		}

		public string GetName() => _name;
		public string GetNumber() => _number;
	}

	public partial class EquipmentES
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
