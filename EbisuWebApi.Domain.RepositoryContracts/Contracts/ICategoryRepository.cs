using EbisuWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Domain.RepositoryContracts.Contracts
{
    public interface ICategoryRepository : IGenericRepository<CategoryEntity>
    {
    }
}
