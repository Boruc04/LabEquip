using MediatR;
using System;

namespace Boruc.LabEquip.Services.Equipment.Application.Commands
{
	public class AddDefinitionOfActionCommand : IRequest
	{
		public string TaskType { get; private set; }
		public string TaskFrequency { get; private set; }
		public DateTime? FirstOccurenceDateTime { get; private set; }

		public AddDefinitionOfActionCommand(DateTime? firstOccurenceDateTime, string taskFrequency, string taskType)
		{
			FirstOccurenceDateTime = firstOccurenceDateTime;
			TaskFrequency = taskFrequency;
			TaskType = taskType;
		}
	}
}
