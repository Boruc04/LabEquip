using MediatR;
using System;

namespace Boruc.LabEquip.Services.Equipment.Application.Commands
{
	public class CreateEquipmentESCommand : IRequest<Guid>
	{
		public string Name { get; private set; }

		public string Number { get; private set; }

		public CreateEquipmentESCommand(string name, string number)
		{
			Name = name;
			Number = number;
		}
	}
}