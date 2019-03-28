using Boruc.LabEquip.Services.Equipping.Domain.Events;
using Boruc.LabEquip.SharedKernel;
using System;

namespace Boruc.LabEquip.Services.Equipping.Domain.AggregatesModel.EquipmentAggregates
{
	public class Equipment : Entity, IAggregateRoot
	{
		private string _name;

		private string _number;

		private int _bookId;
		public Book Book { get; private set; }

		private DateTime _addedDate;

		protected Equipment()
		{
			_addedDate = DateTime.UtcNow;
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
