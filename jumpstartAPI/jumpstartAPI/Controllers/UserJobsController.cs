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
        public async Task<ActionResult<IEnumerable<UserJobs>>> GetUserJobs()
        {
            return await _context.UserJobs.ToListAsync();
        }

        // GET: api/UserJobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserJobs>> GetUserJobs(int id)
        {
            var userJobs = await _context.UserJobs.FindAsync(id);

            if (userJobs == null)
            {
                return NotFound();
            }

            return userJobs;
        }

        // PUT: api/UserJobs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserJobs(int id, UserJobs userJobs)
        {
            if (id != userJobs.UserID)
            {
                return BadRequest();
            }

            _context.Entry(userJobs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserJobsExists(id))
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UserJobs>> PostUserJobs(UserJobs userJobs)
        {
            _context.UserJobs.Add(userJobs);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserJobsExists(userJobs.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserJobs", new { id = userJobs.UserID }, userJobs);
        }

        // DELETE: api/UserJobs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserJobs>> DeleteUserJobs(int id)
        {
            var userJobs = await _context.UserJobs.FindAsync(id);
            if (userJobs == null)
            {
                return NotFound();
            }

            _context.UserJobs.Remove(userJobs);
            await _context.SaveChangesAsync();

            return userJobs;
        }

        private bool UserJobsExists(int id)
        {
            return _context.UserJobs.Any(e => e.UserID == id);
        }
    }
}
