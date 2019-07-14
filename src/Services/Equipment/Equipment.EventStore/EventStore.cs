using Boruc.LabEquip.Services.SharedKernelES;
using EventStore.ClientAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure.EventStore
{
	public sealed class EventStore : IEventStore
	{
		private readonly IEventStoreConnection _eventStore;
		private const string STREAM_NAME_PREFIX = "EquipmentStream_";
		private const long STREAM_START_POSITION = 0;
		private readonly string _connectionString = "ConnectTo=tcp://admin:changeit@localhost:1113; HeartBeatTimeout=500";

		public EventStore()
		{
			_eventStore = EventStoreConnection.Create(_connectionString);
		}

		private void StartConnection()
		{
			_eventStore.ConnectAsync().Wait();
		}

		public void SaveAsync()
		{
			// This should be implemented with transaction scope on Request.
		}

		public void SaveEvents(Guid aggregateId, IEnumerable<IEvent> events, int? expectedVersion)
		{
			using (_eventStore)
			{
				_eventStore.ConnectAsync().Wait();
				foreach (var @event in events)
				{
					_eventStore.AppendToStreamAsync($"{STREAM_NAME_PREFIX}{@event.AggregateId}", expectedVersion ?? ExpectedVersion.NoStream, new EventData(
					@event.Id,
					"Equipment",
					true,
					Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event)),
					Encoding.UTF8.GetBytes("{test:value}")));
				}
				_eventStore.Close();
			}
		}

		public IList<IEvent> GetEventsForAggregate(Guid aggregateId)
		{
			var resolvedEvents= new List<ResolvedEvent>();
			var nextSlice = STREAM_START_POSITION;
			using (_eventStore)
			{
				_eventStore.ConnectAsync().Wait();
				StreamEventsSlice currentSlice;
				do
				{
					currentSlice = _eventStore.ReadStreamEventsForwardAsync($"{STREAM_NAME_PREFIX}{aggregateId}", nextSlice, 200, false).Result;
					resolvedEvents.AddRange(currentSlice.Events);			
					nextSlice = currentSlice.NextEventNumber;
				} while (!currentSlice.IsEndOfStream);
				_eventStore.Close();
			}

			//TODO deserialize event from bytes json.
			//return resolvedEvents.Select(@event => @event.Event.Data.Deserialize )
			throw new NotImplementedException();
			
		}

		public void Dispose()
		{
			_eventStore.Dispose();
		}
	}
}
