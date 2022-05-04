using EbisuWebApi.Crosscutting.Utils;
using EbisuWebApi.Domain.RepositoryContracts.Contracts;
using EbisuWebApi.Infrastructure.DataModel;
using EbisuWebApi.Infrastructure.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Infrastructure.Repositories.Implementations
{
    public class RoleRepository : GenericRepository<RoleDataModel>, IRoleRepository
    {
        public RoleRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<RoleDataModel> GetUserRole()
        {
            return await _context.Roles.FirstOrDefaultAsync(role => role.RoleType.Equals(Enum.Parse(typeof(Role), "User")));
        }
    }
}
