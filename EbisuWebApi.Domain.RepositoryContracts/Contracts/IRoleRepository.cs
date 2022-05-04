using EbisuWebApi.Infrastructure.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Domain.RepositoryContracts.Contracts
{
    public interface IRoleRepository : IGenericRepository<RoleDataModel>
    {
        Task<RoleDataModel> GetUserRole();
      
    }
}
