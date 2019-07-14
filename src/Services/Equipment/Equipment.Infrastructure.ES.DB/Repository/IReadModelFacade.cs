using System;
using System.Collections.Generic;

namespace Equipment.Infrastructure.ES.DB.Repository {
	public interface IReadModelFacade
	{
		dynamic GetEquipment(Guid id);
		IList<dynamic> GetEquipments();
	}
}