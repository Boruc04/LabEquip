namespace Boruc.LabEquip.Services.SharedKernel
{
	public interface IRepository<T> where T : IAggregateRoot
	{
		IUnitOfWork UnitOfWork { get; }
	}
}
