using System;

namespace Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate
{
	using Events;
	using SharedKernel;

	public class Equipment : Entity, IAggregateRoot
	{
		private string _name;

		private string _number;

		public int? GetBookId => _bookId;
		private int? _bookId;

		private DateTime _addedOnUTC;

		protected Equipment()
		{
			_addedOnUTC = DateTime.UtcNow;
		}

		public Equipment(string name, string number) : this()
		{
			_name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
			_number = !string.IsNullOrWhiteSpace(number) ? number : throw new ArgumentNullException(nameof(number));
		}

		private void AddEquipmentAddedDomainEvent()
		{
			var equipmentAddedDomainEvent = new EquipmentAddedDomainEvent(this);
		}
	}
}
