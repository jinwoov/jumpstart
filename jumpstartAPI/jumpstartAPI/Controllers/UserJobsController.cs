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
    [Route("api/userjob")]
    [ApiController]
    public class UserJobsController : ControllerBase
    {
        private readonly JumpStartDbContext _context;

        public UserJobsController(JumpStartDbContext context)
        {
            _context = context;
        }

        // POST: api/UserJobs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost, Route("{userID}/{jobID}")]
        public async Task<ActionResult<UserJob>> PostUserJob(int userID, int jobID)
        {
            UserJob userJob = new UserJob
            {
                UserID = userID,
                JobID = jobID
            };

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
        [HttpDelete, Route("{userID}/{jobID}")]
        public async Task<ActionResult<UserJob>> DeleteUserJob(int userID, int jobID)
        {
            UserJob userJob = new UserJob
            {
                UserID = userID,
                JobID = jobID
            };

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
