namespace Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.PersonAggregate
{
	using Boruc.LabEquip.Services.SharedKernel;
	using System;

	public class Person : Entity, IAggregateRoot
	{
		public string FirstName { get; private set; }
		public string LastName { get; private set; }

		public PhoneNumber PhoneNumber { get; private set; }

		public Room OfficeRoom { get; private set; }	

		public Person() { }

		public Person(string firstName, Room room, string lastName, PhoneNumber phoneNumber)
		{
			FirstName = !string.IsNullOrWhiteSpace(firstName) ? firstName : throw new ArgumentNullException(nameof(firstName));
			OfficeRoom = room ?? throw new ArgumentNullException(nameof(room));
			LastName = !string.IsNullOrWhiteSpace(lastName) ? lastName : throw new ArgumentNullException(nameof(lastName));
			PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
		}
	}
}
