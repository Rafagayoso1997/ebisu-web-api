using EbisuWebApi.Crosscutting.Utils;
using EbisuWebApi.Domain.Services.Contracts;
using EbisuWebApi.Infrastructure.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Domain.Services.Implementations
{
    public class UserDomainService : IUserDomainService
    {
        public void AddDefaultCategoriesToUser(UserDataModel userDataModel, IEnumerable<CategoryDataModel> defaultCategories)
        {
            userDataModel.Categories = new List<CategoryDataModel>();
            userDataModel.Categories.AddRangeToCollection(defaultCategories);
        }
    }
}
