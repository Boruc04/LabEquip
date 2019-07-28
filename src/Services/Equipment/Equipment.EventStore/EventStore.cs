using Boruc.LabEquip.Services.SharedKernelES;
using EventStore.ClientAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure.EventStore
{
	public sealed class EventStore : IEventStore
	{
		private readonly IEventStoreConnection _eventStoreConnection;
		private const string STREAM_NAME_PREFIX = "EquipmentStream_";
		private const long STREAM_START_POSITION = 0;
		private readonly string _connectionString = "ConnectTo=tcp://admin:changeit@localhost:1113; HeartBeatTimeout=500";

		public EventStore()
		{
			_eventStoreConnection = EventStoreConnection.Create(_connectionString);
			_eventStoreConnection.ConnectAsync().Wait();
		}

		public EventStore(IEventStoreConnection eventStoreConnection)
		{
			_eventStoreConnection = eventStoreConnection ?? EventStoreConnection.Create(_connectionString);
		}

		private void StartConnection()
		{
			_eventStoreConnection.ConnectAsync().Wait();
		}

		public void SaveAsync()
		{
			// This should be implemented with transaction scope on Request.
		}

		public void SaveEvents(Guid aggregateId, IEnumerable<IEvent> events, int? expectedVersion)
		{
			foreach (var @event in events)
			{
				var writeResult = _eventStoreConnection.AppendToStreamAsync($"{STREAM_NAME_PREFIX}{@event.AggregateId}", expectedVersion ?? ExpectedVersion.NoStream, new EventData(
				@event.Id,
				@event.GetType().ToString(),
				true,
				Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event)),
				null));
			}
		}

		public IList<IEvent> GetEventsForAggregate(Guid aggregateId)
		{
			var resolvedEvents = new List<ResolvedEvent>();
			var nextSlice = STREAM_START_POSITION;
			_eventStoreConnection.ConnectAsync().Wait();
			StreamEventsSlice currentSlice;
			do
			{
				currentSlice = _eventStoreConnection.ReadStreamEventsForwardAsync($"{STREAM_NAME_PREFIX}{aggregateId}", nextSlice, 200, false).Result;
				resolvedEvents.AddRange(currentSlice.Events);
				nextSlice = currentSlice.NextEventNumber;
			} while (!currentSlice.IsEndOfStream);
			_eventStoreConnection.Close();


			foreach (var resolvedEvent in resolvedEvents)
			{
				byte[] jsonBytes = resolvedEvent.Event.Data;
				string jsonString = Encoding.UTF8.GetString(jsonBytes);
				var eventObject = JsonConvert.DeserializeObject(jsonString);

			}

			//TODO deserialize event from bytes json.
			//return resolvedEvents.Select(@event => @event.Event.Data.Deserialize )
			throw new NotImplementedException();

		}

		public void Dispose()
		{
			_eventStoreConnection.Dispose();
		}
	}
}
