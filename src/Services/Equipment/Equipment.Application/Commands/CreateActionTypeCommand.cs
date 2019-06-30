using MediatR;
using System;

namespace Boruc.LabEquip.Services.Equipment.Application.Commands
{
	public class CreateActionTypeCommand : IRequest<bool>
	{
		public int EquipmentId { get; private set; }
		public int TaskTypeId { get; private set; }
		public int TaskFrequencyId { get; private set; }
		public DateTime FirstOccurenceDateTime { get; private set; }

		public CreateActionTypeCommand(DateTime firstOccurenceDateTime, int taskFrequencyId, int taskTypeId)
		{
			FirstOccurenceDateTime = firstOccurenceDateTime;
			TaskFrequencyId = taskFrequencyId;
			TaskTypeId = taskTypeId;
		}

		public void AddEquipmentId(int equipmentId)
		{
			EquipmentId = equipmentId;
		}
	}
}
