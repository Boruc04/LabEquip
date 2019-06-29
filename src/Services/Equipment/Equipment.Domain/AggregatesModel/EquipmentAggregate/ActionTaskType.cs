using Boruc.LabEquip.Services.Equipment.Domain.Exceptions;
using Boruc.LabEquip.Services.SharedKernel;
using System;
using System.Collections.Generic;

namespace Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate
{
	public class ActionTaskType : Entity
	{
		// ReSharper disable NotAccessedField.Local
		private TaskType _taskType;
		private TaskFrequency _taskFrequency;
		private DateTime _firstOccurrence;
		private List<MaintenanceTaskExecution> _maintenanceTaskExecutions;


		private ActionTaskType()
		{
			_maintenanceTaskExecutions = new List<MaintenanceTaskExecution>();
		}

		public ActionTaskType(TaskType taskType, TaskFrequency taskFrequency, DateTime firstOccurrence) : this()
		{
			_taskType = taskType ?? throw new EquipmentDomainException(nameof(taskType));
			_taskFrequency = taskFrequency ?? throw new EquipmentDomainException(nameof(taskFrequency));
			_firstOccurrence = firstOccurrence;
		}
	}
}