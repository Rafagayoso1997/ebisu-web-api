using EbisuWebApi.Crosscutting.TestUtils.TestTools;
using EbisuWebApi.Infrastructure.DataModel;
using EbisuWebApi.Infrastructure.Repositories.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbisuWebApi.Infrastructure.Unit.UserRepositoryTest
{
    [TestClass]
    public class UserInMemoryRepositoryUnitTest : BaseInMemoryUnitTest
    {
        [TestMethod]
        public async Task AddAsync_HappyPath()
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
            TestDbContext.SaveChanges();

            Assert.IsTrue(await userRepository.UserExist(userDataModel.UserName));
        }

        [TestMethod]
        public async Task Userexists_HappyPath()
        {
            var userRepository = new UserRepository(TestDbContext);
            var userDataModel = new UserDataModel
            {
                UserId = 1,
                UserName = "rafa",
                Email = "rafa@gmail.com",
                Password = "123"
            };
            await userRepository.Add(userDataModel);
            TestDbContext.SaveChanges();

            var actual = await userRepository.UserExist(userDataModel.UserName);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public async Task Userexists_WhenUserNotExists_ReturnsFalse()
        {
            var userRepository = new UserRepository(TestDbContext);
            var userToFind = "David";

            var actual = await userRepository.UserExist(userToFind);

            Assert.IsFalse(actual);
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
            TestDbContext.SaveChanges();
            await userRepository.Delete(userID);
            TestDbContext.SaveChanges();

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
                TestDbContext.SaveChanges();
            }
            var actual = await userRepository.GetAll();
            var count = actual.Count();

            Assert.AreEqual(expectedNumber, count);
        }

        [TestMethod]
        public async Task Login_HappyPath_expected()
        {
            var userRepository = new UserRepository(TestDbContext);
            var userDataModel = new UserDataModel
            {
                UserId = 5,
                UserName = "ana",
                Email = "ana@gmail.com",
                Password = "123"
            };

            await userRepository.Add(userDataModel);
            TestDbContext.SaveChanges();
            var actual = await userRepository.Login(userDataModel);

            Assert.AreEqual(userDataModel, actual);
        }

        [TestMethod]
        public async Task GetEntity_HappyPath()
        {
            var userRepository = new UserRepository(TestDbContext);

            var idToFind = 3;

            var userToFind = new UserDataModel
            {
                UserId = idToFind,
                UserName = "david",
                Email = "david@gmail.com",
                Password = "123"
            };

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
                userToFind,
                new UserDataModel
                {
                    UserId = 4,
                    UserName = "carlos",
                    Email = "carlos@gmail.com",
                    Password = "123"
                }
            };

            foreach (var userDataModel in userDataModels)
            {
                await userRepository.Add(userDataModel);
                TestDbContext.SaveChanges();
            }

            var actual = await userRepository.GetEntity(idToFind);

            Assert.AreEqual(userToFind, actual);

        }
    }
}