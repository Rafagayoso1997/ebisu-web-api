using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Domain.RepositoryContracts.Contracts
{
    public interface IUpdate<T> where T : class
    {
        Task<T> Update(T entity);
    }
}
