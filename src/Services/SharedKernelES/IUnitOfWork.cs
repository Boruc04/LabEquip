using System;

namespace SharedKernelES
{
	public interface IUnitOfWork : IDisposable
	{
		void Commit();
	}
}
