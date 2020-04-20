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
        private readonly IUserManager _context;

        public UsersController(IUserManager context)
        {
            _context = context;
        }


        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await _context.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser(UserDTO userDTO)
        {
            var uDTO = await _context.CreateUser(userDTO);

            return CreatedAtAction("GetUser", new { id = uDTO.ID }, uDTO);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDTO>> DeleteUser(int id)
        {
            var user = await _context.DeleteUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

    }
}
