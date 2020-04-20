using jumpstartAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jumpstartAPI.Models.Interface
{
    public interface IUserManager
    {
        //c
        Task<UserDTO> CreateUser(UserDTO uDTO);

        //r
        Task<UserDTO> GetUser(int id);

        //d
        Task<UserDTO> DeleteUser(int id);
    }
}
