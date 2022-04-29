
using EbisuWebApi.Domain.RepositoryContracts.Contracts;
using EbisuWebApi.Infrastructure.Persistence.DataBaseContext;
using System;

namespace EbisuWebApi.Infrastructure.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        public IUserRepository Users { get; }
        public ICategoryRepository Categories { get; }

        public ITransactionRepository Transactions { get; }

        public UnitOfWork(DatabaseContext context,
            IUserRepository userRepository, ICategoryRepository categoryRepository, ITransactionRepository transactionRepository)
        {
            _context = context;

            Users = userRepository;
            Categories = categoryRepository;
            Transactions = transactionRepository;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
