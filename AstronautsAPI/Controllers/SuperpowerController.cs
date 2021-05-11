using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AstronautsDataLibrary.Db;
using AstronautsDataLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace AstronautsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperpowerController : ControllerBase
    {
        private readonly AstronautsContext _db;

        public SuperpowerController(AstronautsContext db)
        {
            _db = db;
        }

        // GET api/superpower
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Superpower>>> GetSuperpowers()
        {
            return await _db.Superpowers.ToListAsync();
        }

        // GET api/superpower/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Superpower>> GetSuperpower(int id)
        {
            //if (id == 0)
            //{
            //    return BadRequest();
            //}
            var superpower = await _db.Superpowers.FindAsync(id);

            if (superpower == null)
            {
                return NotFound();
            }

            return superpower;
        }

        // POST: api/superpower
        [HttpPost]
        public async Task<ActionResult<Superpower>> PostSuperpower(Superpower superpower)
        {
            if (!SuperpowerExists(superpower.Id))
            {
                _db.Superpowers.Add(superpower);
                await _db.SaveChangesAsync();

                return CreatedAtAction("GetSuperpower", new { id = superpower.Id }, superpower);
            }
            else
            {
                return UnprocessableEntity();
            }
        }

        private bool SuperpowerExists(int id)
        {
            return _db.Superpowers.Any(x => x.Id == id);
        }

        // PUT api/superpower/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuperpower(int id, Superpower superpower)
        {
            if (id != superpower.Id)
            {
                return BadRequest();
            }

            _db.Entry(superpower).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuperpowerExists(id))
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

        // DELETE api/superpower/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuperpower(int id)
        {
            var superpower = await _db.Superpowers.FindAsync(id);
            if (superpower == null)
            {
                return NotFound();
            }

            _db.Superpowers.Remove(superpower);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
