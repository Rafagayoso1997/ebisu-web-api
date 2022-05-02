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
        void AddDefaultCategoriesToUser(UserDataModel userDataModel, IEnumerable<CategoryDataModel> defaultCategories);
    }
}
