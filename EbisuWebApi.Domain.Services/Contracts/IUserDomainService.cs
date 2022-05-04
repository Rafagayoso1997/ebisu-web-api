using EbisuWebApi.Application.Dtos;
using EbisuWebApi.Infrastructure.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Domain.Services.Contracts
{
    public interface IUserDomainService
    {
        Task AddDefaultCategoriesToUser(UserDataModel userDataModel);

        Task AddDefaultRoleToUser(UserDataModel userDataModel);

        Task ValidateUserData(UserDataModel userDataModel);

        Task UserExist(UserDataModel userDataModel);
    }
}
