using FluentValidation;

namespace Boruc.LabEquip.Services.Equipment.Application.Validations
{
	using Boruc.LabEquip.Services.Equipment.Application.Commands;

	public class CreateEquipmentCommandValidator : AbstractValidator<CreateEquipmentCommand>
	{
		public CreateEquipmentCommandValidator()
		{
			RuleFor(command => command.Name).NotEmpty();
			RuleFor(command => command.Number).NotEmpty();
		}
	}
}
