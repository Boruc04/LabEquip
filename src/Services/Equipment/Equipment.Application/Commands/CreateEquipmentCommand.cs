using MediatR;
using System;

namespace Boruc.LabEquip.Services.Equipment.Application.Commands
{
	public class CreateEquipmentCommand : IRequest
	{
		public Guid EquipmentId { get; private set; }
		public string Name { get; private set; }

		public string Number { get; private set; }

		public CreateEquipmentCommand(Guid equipmentId, string name, string number)
		{
			EquipmentId = equipmentId;
			Name = name;
			Number = number;
		}
	}
}