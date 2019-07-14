using System;

namespace Boruc.LabEquip.Services.SharedKernelES
{
	public interface IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
	{
		IUnitOfWork UnitOfWork { get; }
		void Add(TAggregateRoot aggregateRoot, int expectedVersion);
		TAggregateRoot GetById(Guid id);
	}	
}
