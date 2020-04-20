using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jumpstartAPI.Data;
using jumpstartAPI.Models;
using jumpstartAPI.Models.DTO;
using jumpstartAPI.Models.Interface;

namespace jumpstartAPI.Controllers
{
    [Route("api/Job")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobManager _context;

        public JobsController(IJobManager context)
        {
            _context = context;
        }

        // GET: api/Jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDTO>>> GetJobs() => await _context.GetAllJobs();

        // GET: api/Jobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobDTO>> GetJob(int id)
        {
            var job = await _context.GetAJob(id);

            if (job == null)
            {
                return NotFound();
            }

            return job;
        }

        // PUT: api/Jobs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob(int id, JobDTO job)
        {
            if (id != job.ID)
            {
                return BadRequest();
            }

            await _context.UpdateJob(job);


            return NoContent();
        }

        // POST: api/Jobs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<JobDTO>> PostJob(JobDTO job)
        {
            JobDTO jDTO = await _context.CreateJob(job);

            return CreatedAtAction("GetJob", new { id = jDTO.ID }, jDTO);
        }

        // DELETE: api/Jobs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobDTO>> DeleteJob(int id)
        {
            var job = await _context.DeleteJob(id);

            if (job == null)
            {
                return NotFound();
            }


            return job;
        }
    }
}
