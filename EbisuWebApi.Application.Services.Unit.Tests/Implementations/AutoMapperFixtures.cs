using AutoMapper;
using EbisuWebApi.Application.Dtos;
using EbisuWebApi.Domain.Entities;
using EbisuWebApi.Infrastructure.DataModel;
using Moq;
using System.Collections.Generic;

namespace EbisuWebApi.Application.Services.Unit.Tests.Implementations
{
    public static class AutoMapperFixtures
    {
        public static Mock<IMapper> SetupAutoMapperMock()
        {
            var _mockMapper = new Mock<IMapper>();

            _mockMapper.Setup(x => x.Map<UserEntity>(It.IsAny<UserDto>()))
                .Returns(UserFixtures.GetUserEntity()).Verifiable();

            _mockMapper.Setup(x => x.Map<UserDataModel>(It.IsAny<UserEntity>()))
                .Returns(UserFixtures.GetUserDataModel()).Verifiable();

            _mockMapper.Setup(x => x.Map<UserDto>(It.IsAny<UserEntity>()))
                .Returns(UserFixtures.GetUserDto()).Verifiable();

            _mockMapper.Setup(x => x.Map<IEnumerable<UserEntity>>(It.IsAny<IEnumerable<UserDataModel>>()))
                .Returns(UserFixtures.GetUserEntities()).Verifiable();

            _mockMapper.Setup(x => x.Map<IEnumerable<UserDto>>(It.IsAny<IEnumerable<UserEntity>>()))
               .Returns(UserFixtures.GetUserDtos()).Verifiable();

            _mockMapper.Setup(x => x.Map<IEnumerable<UserDataModel>>(It.IsAny<IEnumerable<UserEntity>>()))
               .Returns(UserFixtures.GetUserModels()).Verifiable();

            return _mockMapper;
        }
    }
}
