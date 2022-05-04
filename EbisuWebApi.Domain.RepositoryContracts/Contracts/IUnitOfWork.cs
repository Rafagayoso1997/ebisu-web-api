using System;

namespace EbisuWebApi.Domain.RepositoryContracts.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        ICategoryRepository Categories { get; }

        ITransactionRepository Transactions { get; }

        IRoleRepository Roles { get; }

        int Complete();
    }
}
