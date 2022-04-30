using EbisuWebApi.Domain.Entities;
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
    public class UserRepository : GenericRepository<UserDataModel>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<UserDataModel> Login(UserDataModel userDataModel)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.UserName.ToLower().Equals(userDataModel.UserName.ToLower())
            &&  user.Password.ToLower().Equals(userDataModel.Password.ToLower()));
        }

        public async Task<bool> UserExist(string username) =>
           await _context.Users.AnyAsync(user => user.UserName.ToLower().Equals(username.ToLower()));


    }
}
