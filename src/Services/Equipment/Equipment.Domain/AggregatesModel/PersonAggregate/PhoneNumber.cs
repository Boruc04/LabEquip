namespace Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.PersonAggregate
{
	using Boruc.LabEquip.Services.SharedKernel;
	using System.Collections.Generic;

	public class PhoneNumber : ValueObject
	{
		public string Number { get; private set; }

		public PhoneNumber() { }

		public PhoneNumber(string number)
		{
			Number = number;
		}

		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return Number;
		}
	}
}