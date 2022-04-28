using System;

namespace EbisuWebApi.Domain.RepositoryContracts.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
  
        int Complete();
    }
}
