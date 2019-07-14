using System;

namespace Boruc.LabEquip.Services.Equipment.Application.Queries
{
	public class Equipment
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Number { get; set; }

		public int BookId { get; set; }
	}

	public class EquipmentES
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Number { get; set; }

		public static EquipmentES MapFromEntity(Domain.AggregatesModel.EquipmentAggregateES.EquipmentES equipment)
		{
			switch (equipment)
			{
				case null:
					return new EquipmentES
					{
						Id = Guid.Empty,
						Name = string.Empty,
						Number = string.Empty
					};
				default:
					return new EquipmentES
					{
						Id = equipment.Id,
						Name = equipment.GetName(),
						Number = equipment.GetNumber()
					};
			}
		}
	}
}
