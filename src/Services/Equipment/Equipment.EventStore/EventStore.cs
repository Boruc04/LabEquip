using Boruc.LabEquip.Services.SharedKernelES;
using EventStore.ClientAPI;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.EventStore
{
	public sealed class EventStore : IEventStore
	{
		private readonly IEventStoreConnection _eventStore;
		private const string STREAM_NAME = "testName";
		private readonly Dictionary<string, long> _transactionDictionary;
		private readonly string _connectionString = "ConnectTo=tcp://admin:changeit@localhost:1113; HeartBeatTimeout=500";
		
		public EventStore()
		{
			_transactionDictionary = new Dictionary<string, long>();
			_eventStore = EventStoreConnection.Create(_connectionString);
		}

		private void StartConnection()
		{
			_eventStore.ConnectAsync().Wait();
		}

		private async Task<EventStoreTransaction> StartTransaction(string stream, long expectedVersion)
		{
			var transaction = await _eventStore.StartTransactionAsync(stream, expectedVersion);
			_transactionDictionary.Add(stream, transaction.TransactionId);
			return transaction;
		}

		public void SaveAsync()
		{

		}

		public void SaveEvents(Guid aggregateId, IEnumerable<IEvent> events, int? expectedVersion)
		{
			StartConnection();
			foreach (var @event in events)
			{
				_eventStore.AppendToStreamAsync(STREAM_NAME, expectedVersion ?? ExpectedVersion.NoStream, new EventData(
				@event.Id,
				"EventType",
				true,
				Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event)),
				Encoding.UTF8.GetBytes("{test:value}")));
			}
		}

		public IList<IEvent> GetEventsForAggregate(Guid aggregateId)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			_eventStore.Dispose();
		}
	}
}
