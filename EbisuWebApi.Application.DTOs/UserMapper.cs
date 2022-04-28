using EbisuWebApi.Domain.Entities;
using EbisuWebApi.Infrastructure.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encoding = EbisuWebApi.Crosscutting.Security.Encoding;

namespace EbisuWebApi.Application.DTOs
{
    public static class UserMapper
    {
        public static UserEntity MappUserDTOIntoUserEntity(UserDTO userDto)
        {
            UserEntity webAPIUser = new();
            webAPIUser.UserName = userDto.UserName;
            webAPIUser.Password = Encoding.EncryptStringToBytes_Aes(userDto.Password);
            webAPIUser.Email = userDto.Email;
            return webAPIUser;
        }

        public static UserDTO MappUserEntityIntoUserDTO(UserEntity userEntity)
        {
            UserDTO userDTO = new();
            userDTO.UserName = userEntity.UserName;
            userDTO.Password = userEntity.Password;
            userDTO.Email = userEntity.Email;
            return userDTO;
        }
    }
}
