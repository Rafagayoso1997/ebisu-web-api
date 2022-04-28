using AutoMapper;
using EbisuWebApi.Application.DTOs;
using EbisuWebApi.Application.Services.Contracts;
using EbisuWebApi.Domain.Entities;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
            

        public async Task<UserDTO> AddUserAsync(UserDTO userDTO)
        {
           
            UserEntity entity = await _unitOfWork.Users.Add(_mapper.Map<UserEntity>(userDTO));
            _unitOfWork.Complete();
            return _mapper.Map<UserDTO>(entity);
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {

            return _mapper.Map<IEnumerable<UserDTO>>(await _unitOfWork.Users.GetAll()); ;
        }
    }
}
