using System;

namespace Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate
{
	using SharedKernel;

	public class Book : Entity
	{
		private string _id;

		public Book(string id)
		{
			_id = !string.IsNullOrWhiteSpace(id) ? id : throw new ArgumentNullException(nameof(id));
		}
	}
}