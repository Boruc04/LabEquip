using FluentValidation;

namespace Boruc.LabEquip.Services.Equipment.Application.Validators
{
	using Commands;

	public class CreateEquipmentCommandValidator : AbstractValidator<CreateEquipmentCommand>
	{
		public CreateEquipmentCommandValidator()
		{
			RuleFor(command => command.Name).NotEmpty();
			RuleFor(command => command.Name).MaximumLength(256);
			RuleFor(command => command.Number).NotEmpty();
			RuleFor(command => command.Number).MaximumLength(16);
			RuleFor(command => command.Number).Matches(@"^\d{4}-\d{4}-\d{3}-\d{2}$");
		}
	}
}
