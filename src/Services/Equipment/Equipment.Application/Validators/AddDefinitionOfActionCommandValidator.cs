using Boruc.LabEquip.Services.Equipment.Application.Commands;
using Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate;
using Boruc.LabEquip.Services.SharedKernel;
using FluentValidation;
using System.Linq;

namespace Boruc.LabEquip.Services.Equipment.Application.Validators
{
	public class AddDefinitionOfActionCommandValidator : AbstractValidator<CreateActionTypeCommand>
	{
		public AddDefinitionOfActionCommandValidator()
		{
			RuleFor(command => command.EquipmentId).NotNull();
			RuleFor(command => command.TaskTypeId).NotEqual(0).WithMessage("Task Type cannot be null.");
			RuleFor(command => command.TaskTypeId).Must(IsValidTaskType);
			RuleFor(command => command.TaskFrequencyId).NotEqual(0).WithMessage("Task Frequency cannot be null");
			RuleFor(command => command.TaskFrequencyId).Must(IsValidTaskFrequency);
			RuleFor(command => command.FirstOccurenceDateTime).NotNull().WithMessage("First occurence date cannot be null.");
		}

		private bool IsValidTaskFrequency(int taskFrequencyId)
		{
			return Enumeration.GetAll<TaskFrequency>().Select(type => Enumeration.FromValue<TaskFrequency>(taskFrequencyId)).Any();
		}

		private bool IsValidTaskType(int taskTypeId)
		{
			return Enumeration.GetAll<TaskType>().Select(type => Enumeration.FromValue<TaskType>(taskTypeId)).Any();
		}
	}
}
