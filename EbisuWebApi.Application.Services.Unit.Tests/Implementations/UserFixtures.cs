using EbisuWebApi.Application.Dtos;
using EbisuWebApi.Domain.Entities;
using EbisuWebApi.Infrastructure.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Application.Services.Unit.Tests.Implementations
{
    public class UserFixtures
    {
        public static UserEntity GetUserEntity()
        {
            return new UserEntity
            {
                UserId = 1,
                UserName = "Rafa",
                Password = "123456",
                Email = "gayoso0597@gmail.com"
            };
        }

        public static UserDataModel GetUserDataModel()
        {
            return new UserDataModel
            {
                UserId = 1,
                UserName = "Rafa",
                Password = "123456",
                Email = "gayoso0597@gmail.com",
                Categories = new List<CategoryDataModel>(),
                Roles = new List<RoleDataModel>()
            };
        }

        public static UserDto GetUserDto()
        {
            return new UserDto
            {
                UserId = 1,
                UserName = "Rafa",
                Password = "123456",
                Email = "gayoso0597@gmail.com"
            };
        }

        public static List<UserEntity> GetUserEntities()
        {
            return new List<UserEntity>
            {
               new UserEntity
                {
                    UserId = 1,
                    UserName = "Rafa",
                    Password = "123456",
                    Email = "gayoso0597@gmail.com"
                },
                new UserEntity
                {
                    UserId = 2,
                    UserName = "Rafa",
                    Password = "123456",
                    Email = "gayoso0597@gmail.com"
                },
                 new UserEntity
                {
                    UserId = 3,
                    UserName = "Rafa",
                    Password = "123456",
                    Email = "gayoso0597@gmail.com"
                },
                  new UserEntity
                {
                    UserId = 4,
                    UserName = "Rafa",
                    Password = "123456",
                    Email = "gayoso0597@gmail.com"
                }
            };
        }

        public static List<UserDataModel> GetUserModels()
        {
            return new List<UserDataModel>
            {
               new UserDataModel
                {
                    UserId = 1,
                    UserName = "Rafa",
                    Password = "123456",
                    Email = "gayoso0597@gmail.com",
                    Categories = new List<CategoryDataModel>(),
                    Roles = new List<RoleDataModel>()
                },
                new UserDataModel
                {
                    UserId = 2,
                    UserName = "Rafa",
                    Password = "123456",
                    Email = "gayoso0597@gmail.com",
                    Categories = new List<CategoryDataModel>(),
                    Roles = new List<RoleDataModel>()
                },
                 new UserDataModel
                {
                    UserId = 3,
                    UserName = "Rafa",
                    Password = "123456",
                    Email = "gayoso0597@gmail.com",
                    Categories = new List<CategoryDataModel>(),
                    Roles = new List<RoleDataModel>()
                },
                  new UserDataModel
                {
                    UserId = 4,
                    UserName = "Rafa",
                    Password = "123456",
                    Email = "gayoso0597@gmail.com",
                    Categories = new List<CategoryDataModel>(),
                    Roles = new List<RoleDataModel>()
                }
            };
        }

        public static List<UserDto> GetUserDtos()
        {
            return new List<UserDto>
            {
               new UserDto
                {
                    UserId = 1,
                    UserName = "Rafa",
                    Password = "123456",
                    Email = "gayoso0597@gmail.com"
                },
                new UserDto
                {
                    UserId = 2,
                    UserName = "Rafa",
                    Password = "123456",
                    Email = "gayoso0597@gmail.com"
                },
                 new UserDto
                {
                    UserId = 3,
                    UserName = "Rafa",
                    Password = "123456",
                    Email = "gayoso0597@gmail.com"
                },
                  new UserDto
                {
                    UserId = 4,
                    UserName = "Rafa",
                    Password = "123456",
                    Email = "gayoso0597@gmail.com"
                }
            };
        }
    }
}
