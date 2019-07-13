using System;

namespace Boruc.LabEquip.Services.SharedKernelES
{
	public interface IUnitOfWork : IDisposable
	{
		void SaveAsync();
	}
}
