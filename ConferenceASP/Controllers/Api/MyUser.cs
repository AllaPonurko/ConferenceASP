using ConferenceASP.Data;
using ConferenceASP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConferenceASP.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyUser : ControllerBase
    {
        private readonly IdentityDbContext<MyIdentityUser> _context;

        public MyUser(IdentityDbContext<MyIdentityUser> context)
        {
            _context = context;
        }

        // GET: api/<MyUser>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyIdentityUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET api/<MyUser>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyIdentityUser>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST api/<MyUser>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MyIdentityUser>> PostUser(MyIdentityUser user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // PUT api/<MyUser>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<MyIdentityUser>> PutUser(string id, MyIdentityUser user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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
        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        // DELETE api/<MyUser>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
