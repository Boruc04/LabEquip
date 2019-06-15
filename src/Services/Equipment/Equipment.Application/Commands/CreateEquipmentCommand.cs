﻿using MediatR;

namespace Boruc.LabEquip.Services.Equipment.Application.Commands
{
	public class CreateEquipmentCommand : IRequest
	{
		public string Name { get; private set; }

		public string Number { get; private set; }

		public CreateEquipmentCommand(string name, string number)
		{
			Name = name;
			Number = number;
		}
	}
}