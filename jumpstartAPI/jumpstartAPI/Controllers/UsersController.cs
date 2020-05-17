using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jumpstartAPI.Data;
using jumpstartAPI.Models;
using jumpstartAPI.Models.Interface;
using jumpstartAPI.Models.DTO;

namespace jumpstartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET: api/Users/5
        [HttpGet, Route("{name}")]
        public async Task<ActionResult<UserDTO>> GetUser(string name)
        {
            var user = await _userManager.Getuser(name);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser(User user)
        {
            await _userManager.CreateUser(user);

            return CreatedAtAction("GetUser", new { id = user.ID }, user);
        }


        // DELETE: api/Users/5
        [HttpDelete, Route("{name}")]
        public async Task DeleteUser(string name) => await _userManager.DeleteUser(name);
        
    }
}
