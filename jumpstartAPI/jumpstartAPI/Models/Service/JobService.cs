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
    public class JobService : IJobManager
    {
        private readonly JumpStartDbContext _context;

        public JobService(JumpStartDbContext context)
        {
            _context = context;
        }
        public async Task<JobDTO> CreateJob(JobDTO jobDTO)
        {
            Job newJob = new Job()
            {
                Name = jobDTO.Name,
                Location = jobDTO.Location,
                Company = jobDTO.Company,
                Skills = jobDTO.Skills,
                Tags = (Tag)jobDTO.Tags,
                Summary = jobDTO.Summary,
                Url = jobDTO.Url
            };

            var jobba = _context.Jobs.Add(newJob);
            await _context.SaveChangesAsync();

            await CreateUserJob(jobDTO.UserID);

            return jobDTO;
        }

        public async Task CreateUserJob(int userNumb)
        {
            int lastJob = await _context.Jobs.OrderByDescending(x => x.ID).Select(x => x.ID).FirstAsync();

            UserJobs userJobs = new UserJobs()
            {
                UserID = userNumb,
                JobID = lastJob
            };

            _context.UserJobs.Add(userJobs);

            await _context.SaveChangesAsync();
        }

        public async Task<JobDTO> DeleteJob(int id)
        {
            Job deleteJob = await _context.Jobs.FindAsync(id);

            _context.Jobs.Remove(deleteJob);

            await _context.SaveChangesAsync();

            JobDTO jDTO = ConvertToDTO(deleteJob);

            return jDTO;
        }

        public async Task<JobDTO> GetAJob(int id)
        {
            Job thisJob = await _context.Jobs.FindAsync(id);

            JobDTO jobDTO = ConvertToDTO(thisJob);

            return jobDTO;
        }

        public async Task<List<JobDTO>> GetAllJobs()
        {
            List<Job> jobList = await _context.Jobs.ToListAsync();

            List<JobDTO> jDTOList = new List<JobDTO>();

            foreach (var job in jobList)
            {
                JobDTO jDTO = ConvertToDTO(job);

                jDTOList.Add(jDTO);
            }

            return jDTOList;
        }

        public async Task<JobDTO> UpdateJob(JobDTO jobDTO)
        {
            Job job = new Job()
            {
                Name = jobDTO.Name,
                Location = jobDTO.Location,
                Company = jobDTO.Company,
                Skills = jobDTO.Skills,
                Tags = (Tag)jobDTO.Tags,
                Summary = jobDTO.Summary,
                Url = jobDTO.Url
            };

            _context.Jobs.Update(job);

            await _context.SaveChangesAsync();

            return jobDTO;
        }

        private JobDTO ConvertToDTO(Job job)
        {
            JobDTO jDTO = new JobDTO()
            {
                ID = job.ID,
                Name = job.Name,
                Location = job.Location,
                Company = job.Company,
                Skills = job.Skills,
                Summary = job.Summary,
                Tags = Convert.ToInt32(job.Tags),
                Url = job.Url
            };

            return jDTO;
        }
    }
}
