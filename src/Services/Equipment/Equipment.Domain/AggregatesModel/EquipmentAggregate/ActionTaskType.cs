using Boruc.LabEquip.Services.SharedKernel;
using System;
using System.Collections.Generic;

namespace Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate
{
	public class ActionTaskType : Entity
	{
		public TaskType TaskType { get; private set; }
		private int _taskTypeId;

		public TaskFrequency TaskFrequency { get; private set; }
		private int _taskFrequencyId;

		private DateTime _firstOccurrence;

		private List<ActionTaskExecution> _actionTaskExecutions;

		private ActionTaskType()
		{
			_actionTaskExecutions = new List<ActionTaskExecution>();
		}

		public ActionTaskType(int taskTypeId, int taskFrequencyId, DateTime firstOccurrence) : this()
		{
			_taskTypeId = taskTypeId;
			_taskFrequencyId = taskFrequencyId;
			_firstOccurrence = firstOccurrence;
		}
	}
}