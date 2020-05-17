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
        private readonly JumpStartDbContext _jumpDbContext;
        private readonly IJobManager _jobManager;

        public UserService(JumpStartDbContext jumpDbContext, IJobManager jobManager)
        {
            _jumpDbContext = jumpDbContext;
            _jobManager = jobManager;
        }
        public async Task CreateUser(User user)
        {
            _jumpDbContext.Users.Add(user);
            await _jumpDbContext.SaveChangesAsync();
        }

        public async Task<List<JobDTO>> GetJobsUsingUser(string userName)
        {
            var user = await _jumpDbContext.Users.Where(x => x.UserName == userName).SingleAsync();

            var jobs = await _jumpDbContext.UserJob.Where(x => x.UserID == user.ID).ToListAsync();

            List<JobDTO> joblist = new List<JobDTO>();

            foreach (var job in jobs)
            {
                var searchedJob = await _jobManager.GetAJob(job.JobID);
                joblist.Add(searchedJob);
            }

            return joblist;
            
        }

        public async Task<UserDTO> Getuser(string userName)
        {
            var user = await _jumpDbContext.Users.Where(x => x.UserName == userName).SingleAsync();
            var userDTO = ConvertToDTO(user);
            userDTO.Jobs = await GetJobsUsingUser(userName);

            return userDTO;
        }

        public UserDTO ConvertToDTO(User user)
        {
            UserDTO userDTO = new UserDTO
            {
                ID = user.ID,
                UserName = user.UserName
            };

            return userDTO;
        }
    }
}
