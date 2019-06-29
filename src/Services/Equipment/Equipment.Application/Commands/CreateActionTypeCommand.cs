using MediatR;
using System;

namespace Boruc.LabEquip.Services.Equipment.Application.Commands
{
	public class CreateActionTypeCommand : IRequest<bool>
	{
		public int EquipmentId { get; private set; }
		public string TaskType { get; private set; }
		public string TaskFrequency { get; private set; }
		public DateTime FirstOccurenceDateTime { get; private set; }

		public CreateActionTypeCommand(DateTime firstOccurenceDateTime, string taskFrequency, string taskType)
		{
			FirstOccurenceDateTime = firstOccurenceDateTime;
			TaskFrequency = taskFrequency;
			TaskType = taskType;
		}

		public void AddEquipmentId(int equipmentId)
		{
			EquipmentId = equipmentId;
		}
	}
}
