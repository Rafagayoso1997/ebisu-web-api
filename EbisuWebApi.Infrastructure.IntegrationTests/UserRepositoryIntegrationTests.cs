using EbisuWebApi.Infrastructure.DataModel;
using EbisuWebApi.Infrastructure.IntegrationTests.TestTools;
using EbisuWebApi.Infrastructure.Repositories.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Infrastructure.IntegrationTests
{
    [TestClass]
    public class UserRepositoryIntegrationTests : BaseIntegrationTests
    {
        [TestMethod]
        public async Task AddAsync()
        {

            var userRepository = new UserRepository(TestDbContext);
            var userDataModel = new UserDataModel
            {
                UserId = 1,
                UserName = "paco",
                Email = "paco@gmail.com",
                Password = "123"
            };
            await userRepository.Add(userDataModel);
            Assert.IsTrue(await userRepository.UserExist(userDataModel.UserName));
        }

        [TestMethod]
        public async Task Delete_Happypath()
        {
            var userRepository = new UserRepository(TestDbContext);
            var userID = 1;
            var userDataModel = new UserDataModel
            {
                UserId = userID,
                UserName = "lucia",
                Email = "lucia@gmail.com",
                Password = "123"
            };

            await userRepository.Add(userDataModel);
            await userRepository.Delete(userID);

            Assert.IsFalse(await userRepository.UserExist(userDataModel.UserName));
        }

        [TestMethod]
        public async Task GetAll_expected3()
        {
            var userRepository = new UserRepository(TestDbContext);
            var expectedNumber = 3;
            var userDataModels = new List<UserDataModel>
            {
                new UserDataModel
                {
                    UserId = 1,
                    UserName = "paco",
                    Email = "paco@gmail.com",
                    Password = "123"
                },
                new UserDataModel
                {
                    UserId = 2,
                    UserName = "lucia",
                    Email = "lucia@gmail.com",
                    Password = "123"
                },
                new UserDataModel
                {
                    UserId = 3,
                    UserName = "carlos",
                    Email = "carlos@gmail.com",
                    Password = "123"
                }
            };

            foreach (var userDataModel in userDataModels)
            {
                await userRepository.Add(userDataModel);
            }

            var actual = await userRepository.GetAll();
            var count = actual.Count();

            Assert.AreEqual(expectedNumber, count);
        }




    }
}
