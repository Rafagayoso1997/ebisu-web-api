using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Domain.RepositoryContracts.Contracts
{
    public interface IGenericRepository<T> : IAdd<T>, IUpdate<T>, IDelete<T>, IGetAll<T>, IGet<T> where T : class
    {
    }
}
