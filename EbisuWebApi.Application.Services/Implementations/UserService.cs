using AutoMapper;
using EbisuWebApi.Application.DTOs;
using EbisuWebApi.Application.Services.Contracts;
using EbisuWebApi.Domain.Entities;
using EbisuWebApi.Domain.RepositoryContracts.Contracts;
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

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
            

        public async Task<UserDTO> AddUserAsync(UserDTO userDTO)
        {
            UserDataModel entityDataModel = _mapper.Map<UserDataModel>(_mapper.Map<UserEntity>(userDTO));
            
            var result = await _unitOfWork.Users.Add(entityDataModel);
            _unitOfWork.Complete();
            
            return _mapper.Map<UserDTO>(_mapper.Map<UserEntity>(result));
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {

            return _mapper.Map<IEnumerable<UserDTO>>(_mapper.Map < IEnumerable < UserEntity >>( await _unitOfWork.Users.GetAll()));
        }

        public async Task<UserDTO> GetById(int id)
        {

            return _mapper.Map<UserDTO>(_mapper.Map<UserEntity>(await _unitOfWork.Users.GetEntity(id)));
            //_unitOfWork.Complete();
        }

        public async Task<UserDTO> RemoveUser(int id)
        {
            var userDto = _mapper.Map<UserDTO>(_mapper.Map<UserEntity>(await _unitOfWork.Users.Delete(id)));
           
            _unitOfWork.Complete();
            return userDto;
        }

        public async Task<UserDTO> UpdateUser(UserDTO userDTO)
        {
            UserDataModel entityDataModel = _mapper.Map<UserDataModel>(_mapper.Map<UserEntity>(userDTO));

            var result = await _unitOfWork.Users.Update(entityDataModel);
            _unitOfWork.Complete();

            return _mapper.Map<UserDTO>(_mapper.Map<UserEntity>(result));
        }
    }
}
