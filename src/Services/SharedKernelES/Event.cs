using System;

namespace Boruc.LabEquip.Services.SharedKernelES
{
	public class Event : IEvent
	{
		public Guid Id { get; private set; }
		public Guid AggregateId { get; protected set; }
		public int Version { get; set; }
		public DateTime EventCreationDateTimeUTC { get; private set; }

		protected Event()
		{
			Id = Guid.NewGuid();
			EventCreationDateTimeUTC = DateTime.UtcNow;
		}
	}
}
