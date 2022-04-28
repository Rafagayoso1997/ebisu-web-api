using EbisuWebApi.Domain.Entities;
using EbisuWebApi.Domain.RepositoryContracts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Infrastructure.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        public async Task<UserEntity> Add(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserEntity> Delete(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<UserEntity> GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserEntity> Update(UserEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
