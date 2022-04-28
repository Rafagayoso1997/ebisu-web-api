﻿using EbisuWebApi.Application.DTOs;
using EbisuWebApi.Application.Services.Contracts;
using EbisuWebApi.Domain.RepositoryContracts.Contracts;
using EbisuWebApi.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService( IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync() =>
            await _userRepository.GetAll().Select(x => UserMapper.MappUserEntityIntoUserDTO(x));

        public async Task<IEnumerable<UserDTO>> AddUserAsync(UserDTO userDTO) =>
            _userRepository.Add(UserMapper.MappUserDTOIntoUserEntity(userDTO));
    }
}
