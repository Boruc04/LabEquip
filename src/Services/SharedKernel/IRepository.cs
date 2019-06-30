namespace Boruc.LabEquip.Services.SharedKernel
{
	// ReSharper disable All
	public interface IRepository<T> where T : IAggregateRoot
	{
		IUnitOfWork UnitOfWork { get; }
	}
}
