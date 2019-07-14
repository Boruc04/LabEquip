using System;

namespace Boruc.LabEquip.Services.Equipment.Application.Queries
{
	public class EquipmentViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Number { get; set; }

		public int BookId { get; set; }
	}

	public class EquipmentESViewModel
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Number { get; set; }

		public static EquipmentESViewModel MapFromEntity(dynamic equipment)
		{
			try
			{
				return new EquipmentESViewModel
				{
					Id = equipment.Id,
					Name = equipment.GetName(),
					Number = equipment.GetNumber()
				};
			}
			catch (Exception)
			{
				//Try parse dynamic other way return empty
			}
			return new EquipmentESViewModel
			{
				Id = Guid.Empty,
				Name = string.Empty,
				Number = string.Empty
			};
		}
	}
}
