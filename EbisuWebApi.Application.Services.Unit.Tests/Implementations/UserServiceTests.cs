using Microsoft.VisualStudio.TestTools.UnitTesting;
using EbisuWebApi.Application.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using EbisuWebApi.Domain.RepositoryContracts.Contracts;
using EbisuWebApi.Application.Services.Contracts;
using EbisuWebApi.Domain.Services.Contracts;
using AutoMapper;
using EbisuWebApi.Application.Services.Unit.Tests.Implementations;
using EbisuWebApi.Domain.Entities;
using EbisuWebApi.Infrastructure.DataModel;
using EbisuWebApi.Application.Dtos;

namespace EbisuWebApi.Application.Services.Implementations.Unit.Tests
{
    [TestClass()]
    public class UserServiceTests
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IUserDomainService> _mockUserDomainService;
        private Mock<IMapper> _mockMapper;
        private IUserService _userService;


        [TestInitialize]
        public void Setup()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();

            _mockUnitOfWork.Setup(unit => unit.Users.GetAll()).
                ReturnsAsync(UserFixtures.GetUserModels().ToList());
            
            _mockUnitOfWork.Setup(unit => unit.Users.Add(It.IsAny<UserDataModel>())).
                ReturnsAsync(UserFixtures.GetUserDataModel());

            _mockUnitOfWork.Setup(unit => unit.Users.GetEntity(It.IsAny<int>())).
                ReturnsAsync(UserFixtures.GetUserDataModel());

            _mockUnitOfWork.Setup(unit => unit.Users.Delete(It.IsAny<int>())).
                 ReturnsAsync(UserFixtures.GetUserDataModel());

            _mockUnitOfWork.Setup(unit => unit.Users.Update(It.IsAny<UserDataModel>())).
                ReturnsAsync(It.IsAny<UserDataModel>());

            _mockMapper = AutoMapperFixtures.SetupAutoMapperMock();

            _mockUserDomainService = new Mock<IUserDomainService>();

            _userService = new UserService(_mockUnitOfWork.Object, _mockMapper.Object, _mockUserDomainService.Object);
        }

        [TestMethod()]
        public async Task AddUserAsyncTest()
        {
            UserDto userToInsert = new UserDto
            {
                UserId = 1,
                UserName = "Rafa",
                Password = "123456",
                Email = "gayoso0597@gmail.com"
            };

            UserDto user = await _userService.AddUserAsync(userToInsert);

            _mockUnitOfWork.Verify(unit => unit.Users.Add(It.IsAny<UserDataModel>()), Times.Once);
            
            _mockMapper.Verify(mapper => mapper.Map<UserEntity>(It.IsAny<UserDataModel>()),
               Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<UserDto>(It.IsAny<UserEntity>()),
                Times.Once);

            Assert.AreEqual(UserFixtures.GetUserDto(), user);
           
            Assert.IsNotNull(user);
        }

        [TestMethod()]
        public async Task GetAllTest()
        {
            IEnumerable<UserDto> users = await _userService.GetAll();

            _mockUnitOfWork.Verify(unit => unit.Users.GetAll(), Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<IEnumerable<UserEntity>>(It.IsAny<IEnumerable<UserDataModel>>()),
                Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<IEnumerable<UserDto>>(It.IsAny<IEnumerable<UserEntity>>()),
                Times.Once);

            Assert.AreEqual(UserFixtures.GetUserDtos().Count(), users.Count());
            Assert.IsTrue(users.Any());
            Assert.IsNotNull(users);

        }

        [TestMethod()]
        public async Task GetByIdTest()
        {
            UserDto user = await _userService.GetById(1);

            _mockUnitOfWork.Verify(unit => unit.Users.GetEntity(It.IsAny<int>()), Times.Once);

            _mockMapper.Verify(mapper => mapper.Map<UserEntity>(It.IsAny<UserDataModel>()),
               Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<UserDto>(It.IsAny<UserEntity>()),
                Times.Once);

            Assert.AreEqual(UserFixtures.GetUserDto(), user);
            Assert.AreEqual(user.UserId, 1);
            Assert.IsNotNull(user);
        }
        
        [TestMethod()]
        public async Task RemoveUserTest()
        {
            UserDto user = await _userService.RemoveUser(1);

            _mockUnitOfWork.Verify(unit => unit.Users.Delete(It.IsAny<int>()), Times.Once);

            _mockMapper.Verify(mapper => mapper.Map<UserEntity>(It.IsAny<UserDataModel>()),
               Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<UserDto>(It.IsAny<UserEntity>()),
                Times.Once);

            Assert.AreEqual(UserFixtures.GetUserDto(), user);
            Assert.AreEqual(user.UserId, 1);
            Assert.IsNotNull(user);
        }

        [TestMethod()]
        public async Task UpdateUserTest()
        {
            UserDto userDtoUpdate = new UserDto
            {
                UserId = 1,
                UserName = "Pepe",
                Password = "123456",
                Email = "as@gmail.com"
            };
            
            UserDto user = await _userService.UpdateUser(userDtoUpdate);

            _mockUnitOfWork.Verify(unit => unit.Users.Update(It.IsAny<UserDataModel>()), Times.Once);

            _mockMapper.Verify(mapper => mapper.Map<UserEntity>(It.IsAny<UserDataModel>()),
               Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<UserDto>(It.IsAny<UserEntity>()),
                Times.Once);

            Assert.AreEqual(UserFixtures.GetUserDto(), user);
            Assert.IsNotNull(user);
        }
    }

}