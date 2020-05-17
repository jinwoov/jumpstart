using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jumpstartAPI.Data;
using jumpstartAPI.Models;

namespace jumpstartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserJobsController : ControllerBase
    {
        private readonly JumpStartDbContext _context;

        public UserJobsController(JumpStartDbContext context)
        {
            _context = context;
        }

        // GET: api/UserJobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserJob>>> GetUserJob()
        {
            return await _context.UserJob.ToListAsync();
        }

        // GET: api/UserJobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserJob>> GetUserJob(int id)
        {
            var userJob = await _context.UserJob.FindAsync(id);

            if (userJob == null)
            {
                return NotFound();
            }

            return userJob;
        }

        // PUT: api/UserJobs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserJob(int id, UserJob userJob)
        {
            if (id != userJob.UserID)
            {
                return BadRequest();
            }

            _context.Entry(userJob).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserJobExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserJobs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserJob>> PostUserJob(UserJob userJob)
        {
            _context.UserJob.Add(userJob);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserJobExists(userJob.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserJob", new { id = userJob.UserID }, userJob);
        }

        // DELETE: api/UserJobs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserJob>> DeleteUserJob(int id)
        {
            var userJob = await _context.UserJob.FindAsync(id);
            if (userJob == null)
            {
                return NotFound();
            }

            _context.UserJob.Remove(userJob);
            await _context.SaveChangesAsync();

            return userJob;
        }

        private bool UserJobExists(int id)
        {
            return _context.UserJob.Any(e => e.UserID == id);
        }
    }
}
