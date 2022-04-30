using EbisuWebApi.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Application.Services.Contracts
{
    public interface IUserService
    {
        Task<UserDto> AddUserAsync(UserDto userDTO);

        Task<IEnumerable<UserDto>> GetAll();

        Task<UserDto> GetById(int id);

        Task<UserDto> UpdateUser(UserDto userDTO);

        Task<UserDto> RemoveUser(int id);
    }
}
