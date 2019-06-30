namespace Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.PersonAggregate
{
	using System.Collections.Generic;
	using Boruc.LabEquip.Services.SharedKernel;

	public class Room : ValueObject
	{
		public string RoomNumber { get; private set; }

		public Room() { }

		public Room(string roomNumber)
		{
			RoomNumber = roomNumber;
		}

		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return RoomNumber;
		}
	}
}
