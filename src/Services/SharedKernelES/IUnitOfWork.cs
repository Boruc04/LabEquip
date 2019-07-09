using System;
using System.Threading.Tasks;
using MediatR;

namespace SharedKernelES
{
	public interface IUnitOfWork : IDisposable
	{
		void saveAsync();
	}
}
