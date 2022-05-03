﻿using AutoMapper;
using EbisuWebApi.Application.Dtos;
using EbisuWebApi.Application.Services.Contracts;
using EbisuWebApi.Crosscutting.Exceptions;
using EbisuWebApi.Domain.Entities;
using EbisuWebApi.Domain.RepositoryContracts.Contracts;
using EbisuWebApi.Domain.Services.Contracts;
using EbisuWebApi.Infrastructure.DataModel;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserDomainService _userDomainService;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IUserDomainService userDomainService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userDomainService = userDomainService;
        }

        public async Task<UserDto> AddUserAsync(UserDto userDTO)
        {


            UserDataModel entityDataModel = _mapper.Map<UserDataModel>(_mapper.Map<UserEntity>(userDTO));

            await _userDomainService.ValidateUserData(entityDataModel);
            
            await _userDomainService.UserExist(entityDataModel);

            var defaultCategories = await _unitOfWork.Categories.GetDefaultCategories();

            _userDomainService.AddDefaultCategoriesToUser(entityDataModel, defaultCategories);

            var result = await _unitOfWork.Users.Add(entityDataModel);
            _unitOfWork.Complete();

            return _mapper.Map<UserDto>(_mapper.Map<UserEntity>(result));

        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {

            return _mapper.Map<IEnumerable<UserDto>>(_mapper.Map<IEnumerable<UserEntity>>(await _unitOfWork.Users.GetAll()));
        }

        public async Task<UserDto> GetById(int id)
        {

            return _mapper.Map<UserDto>(_mapper.Map<UserEntity>(await _unitOfWork.Users.GetEntity(id)));
            //_unitOfWork.Complete();
        }

        public async Task<UserLoginTokenDto> LoginUser(UserLoginDto userDTO)
        {
            UserDataModel entityDataModel = _mapper.Map<UserDataModel>(_mapper.Map<UserEntity>(userDTO));

            UserLoginTokenDto userLoginTokenDto = _mapper.Map<UserLoginTokenDto>(_mapper.Map<UserEntity>(await _unitOfWork.Users.Login(entityDataModel)));

            if (userLoginTokenDto == null) throw new IncorrectCredentials();

            return userLoginTokenDto;
        }

        public async Task<UserDto> RemoveUser(int id)
        {
            var userDto = _mapper.Map<UserDto>(_mapper.Map<UserEntity>(await _unitOfWork.Users.Delete(id)));

            _unitOfWork.Complete();
            return userDto;
        }

        public async Task<UserDto> UpdateUser(UserDto userDTO)
        {
            UserDataModel entityDataModel = _mapper.Map<UserDataModel>(_mapper.Map<UserEntity>(userDTO));

            await _userDomainService.ValidateUserData(entityDataModel);            
            
            var result = await _unitOfWork.Users.Update(entityDataModel);
            _unitOfWork.Complete();

            return _mapper.Map<UserDto>(_mapper.Map<UserEntity>(result));
        }
    }
}
