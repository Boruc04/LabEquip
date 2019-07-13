using System;

namespace Boruc.LabEquip.Services.SharedKernelES
{
	public interface IRepository<out TAggregateRoot> where TAggregateRoot : AggregateRoot
	{
		IUnitOfWork UnitOfWork { get; }
	}	
}
