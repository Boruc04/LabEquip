using FluentValidation;

namespace Boruc.LabEquip.Services.Equipment.Application.Validators
{
	using Commands;

	public class CreateEquipmentCommandValidator : AbstractValidator<CreateEquipmentCommand>
	{
		public CreateEquipmentCommandValidator()
		{
			RuleFor(command => command.Name).NotEmpty();
			RuleFor(command => command.Number).NotEmpty();
		}
	}
}
