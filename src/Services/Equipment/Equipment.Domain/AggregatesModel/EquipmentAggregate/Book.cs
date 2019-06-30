using System;

namespace Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate
{
	using SharedKernel;

	public class Book : Entity
	{
		// ReSharper disable once NotAccessedField.Local
		private string _id;

		protected Book()
		{
		}

		public Book(string id)
		{
			_id = !string.IsNullOrWhiteSpace(id) ? id : throw new ArgumentNullException(nameof(id));
		}
	}
}