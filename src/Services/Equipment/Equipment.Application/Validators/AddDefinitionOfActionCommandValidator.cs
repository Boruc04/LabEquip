using Boruc.LabEquip.Services.Equipment.Application.Commands;
using Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate;
using Boruc.LabEquip.Services.SharedKernel;
using FluentValidation;
using System.Linq;

namespace Boruc.LabEquip.Services.Equipment.Application.Validators
{
	public class AddDefinitionOfActionCommandValidator : AbstractValidator<AddDefinitionOfActionCommand>
	{
		public AddDefinitionOfActionCommandValidator()
		{
			RuleFor(command => command.TaskType).NotNull().WithMessage("Task Type cannot be null.");
			RuleFor(command => command.TaskType).Must(IsValidTaskType);
			RuleFor(command => command.TaskFrequency).NotNull().WithMessage("Task Frequency cannot be null");
			RuleFor(command => command.TaskFrequency).Must(IsValidTaskFrequency);
			RuleFor(command => command.FirstOccurenceDateTime).NotNull().WithMessage("First occurence date cannot be null.");
		}

		private bool IsValidTaskFrequency(string taskFrequency)
		{
			return Enumeration.GetAll<TaskFrequency>().Any(type => type.Name == taskFrequency);
		}

		private bool IsValidTaskType(string taskType)
		{
			return Enumeration.GetAll<TaskType>().Any(type => type.Name == taskType);
		}
	}
}
