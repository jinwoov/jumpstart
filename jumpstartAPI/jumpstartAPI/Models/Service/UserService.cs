using jumpstartAPI.Data;
using jumpstartAPI.Models.DTO;
using jumpstartAPI.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jumpstartAPI.Models.Service
{
    public class UserService : IUserManager
    {
        private readonly JumpStartDbContext _context;
        private readonly IJobManager _jobContext;

        public UserService(JumpStartDbContext context, IJobManager jobContext)
        {
            _context = context;
            _jobContext = jobContext;
        }

        public async Task<UserDTO> CreateUser(UserDTO uDTO)
        {
            User newUser = new User()
            {
                UserName = uDTO.UserName
            };

            _context.Users.Add(newUser);

            await _context.SaveChangesAsync();

            return uDTO;
        }

        public async Task<UserDTO> DeleteUser(int id)
        {
            User deleteUser = await _context.Users.FindAsync(id);

            _context.Users.Remove(deleteUser);

            await _context.SaveChangesAsync();

            var uDTO = ConvertToDTO(deleteUser);

            return uDTO;
        }

        public async Task<UserDTO> GetUser(UserDTO users)
        {
            try
            {
                var user = await _context.Users.Where(x => x.UserName == users.UserName).SingleAsync();

                UserDTO uDTO = ConvertToDTO(user);

                uDTO.JobList = await GetJobForUser(user.ID);

                return uDTO;
            }
            catch (Exception)
            {
                return null;
            }
           
        }

        public async Task<List<JobDTO>> GetJobForUser(int id)
        {
            var jobUser = await _context.UserJobs.Where(x => x.UserID == id)
                                                 .ToListAsync();

            List<JobDTO> jobDTOs = new List<JobDTO>();

            foreach (var job in jobUser)
            {
                JobDTO uDTO = await _jobContext.GetAJob(job.JobID);

                jobDTOs.Add(uDTO);
            }

            return jobDTOs;
        }

        private UserDTO ConvertToDTO(User user)
        {
            UserDTO userDTO = new UserDTO()
            {
                ID = user.ID,
                UserName = user.UserName
            };

            return userDTO;
        }
    }
}
