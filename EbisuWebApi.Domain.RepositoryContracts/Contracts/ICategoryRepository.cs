﻿using EbisuWebApi.Domain.Entities;
using EbisuWebApi.Infrastructure.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Domain.RepositoryContracts.Contracts
{
    public interface ICategoryRepository : IGenericRepository<CategoryDataModel>
    {
        Task<IEnumerable<CategoryDataModel>> GetDefaultCategories();

        Task<IEnumerable<CategoryDataModel>> GetCategoriesbyUser(int userId);
    }
}
