using jumpstartAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jumpstartAPI.Models.Interface
{
    public interface IUserManager
    {
        // Create User
        Task CreateUser(User user);

        Task<UserDTO> Getuser(string userName);

        //Get Jobs by Users id
        Task<List<JobDTO>> GetJobsUsingUser(string userName);

        Task DeleteUser(string userName);

    }
}
