using System;
using System.Collections.Generic;

namespace Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate
{
	using Events;
	using SharedKernel;

	public class Equipment : Entity, IAggregateRoot
	{
		private string _name;
		private string _number;

		//TODO:public int? GetBookId => _bookId;
		//TODO:private int? _bookId;

		private DateTime _addedOnUTC;

		private readonly List<ActionTaskType> _actionTaskTypes;

		protected Equipment()
		{
			_addedOnUTC = DateTime.UtcNow;
			_actionTaskTypes = new List<ActionTaskType>();
		}

		public Equipment(string name, string number) : this()
		{
			_name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
			_number = !string.IsNullOrWhiteSpace(number) ? number : throw new ArgumentNullException(nameof(number));

			AddEquipmentAddedDomainEvent();
		}

		public void AddActionType(DateTime firstOccurrence, TaskFrequency taskFrequency, TaskType taskType)
		{
			var actionTaskType = new ActionTaskType(taskType, taskFrequency, firstOccurrence);
			_actionTaskTypes.Add(actionTaskType);
		}



		private void AddEquipmentAddedDomainEvent()
		{
			var equipmentAddedDomainEvent = new EquipmentAddedDomainEvent(this);
			this.AddDomainEvent(equipmentAddedDomainEvent);
		}
	}
}
