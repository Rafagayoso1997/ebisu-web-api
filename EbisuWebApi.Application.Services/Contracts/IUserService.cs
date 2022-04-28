using EbisuWebApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Application.Services.Contracts
{
    public interface IUserService
    {
        Task<UserDTO> AddUserAsync(UserDTO userDTO);

        Task<IEnumerable<UserDTO>> GetAll();
    }
}
