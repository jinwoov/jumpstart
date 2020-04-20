using jumpstartAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jumpstartAPI.Models.Interface
{
    public interface IJobManager
    {
        //c
        public Task<JobDTO> CreateJob(JobDTO jobDTO);

        //r
        public Task<JobDTO> GetAJob(int id);

        //ra
        public Task<List<JobDTO>> GetAllJobs();

        //u
        public Task<JobDTO> UpdateJob(JobDTO jobDTO);

        //d
        public Task<JobDTO> DeleteJob(int id);
    }
}
