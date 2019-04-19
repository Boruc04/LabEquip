using Boruc.LabEquip.Services.Equipment.Domain.Events;
using Boruc.LabEquip.Services.SharedKernel;
using System;

namespace Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregates
{
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

		public Equipment(string name, string number, Book book) : this()
		{
			_name = name;
			_number = number;
			_bookId = book.Id;
		}

		private void AddEquipmentAddedDomainEvent()
		{
			var equipmentAddedDomainEvent = new EquipmentAddedDomainEvent(this);
		}
	}
}
