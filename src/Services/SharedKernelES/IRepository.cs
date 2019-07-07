using System;

namespace SharedKernelES
{
	public interface IRepository<out TAggregateRoot> where TAggregateRoot : AggregateRoot
	{
		IUnitOfWork UnitOfWork { get; }
		void Save(AggregateRoot aggregateRoot, int expectedVersion);
		TAggregateRoot GetById(Guid id);
	}	
}
