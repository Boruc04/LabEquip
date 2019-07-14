using Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregateES;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Equipment.Infrastructure.ES.DB.Repository
{
	public class QueryEquipmentRepository : IReadModelFacade, IReadModelFacadeWrite
	{
		private readonly FakeDb _fakeDb;

		public QueryEquipmentRepository()
		{
			_fakeDb = new FakeDb();
		}

		public dynamic GetEquipment(Guid id)
		{
			return _fakeDb.EquipmentDB.Where(equipment => equipment.Id == id);
		}

		public IList<dynamic> GetEquipments()
		{
			return (IList<dynamic>) _fakeDb.EquipmentDB;
		}

		public void AddEquipment(EquipmentES equipment)
		{
			_fakeDb.EquipmentDB.Add(new EquipmentEntityFakeDb { Id = equipment.Id, Name = equipment.GetName(), Number = equipment.GetNumber() });
		}
	}

	//Fake ReadModel database
	internal class FakeDb
	{
		private static readonly IList<EquipmentEntityFakeDb> EquipmentEntityFakeDbs;

		static FakeDb()
		{
			EquipmentEntityFakeDbs = new List<EquipmentEntityFakeDb>();
		}

		public IList<EquipmentEntityFakeDb> EquipmentDB => EquipmentEntityFakeDbs;
	}

	internal class EquipmentEntityFakeDb
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Number { get; set; }
	}
}
