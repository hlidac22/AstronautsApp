using AstronautsDataLibrary.Db;
using AstronautsDataLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstronautsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AstronautController : ControllerBase
    {
        private readonly AstronautsContext _db;

        public AstronautController(AstronautsContext db)
        {
            _db = db;
        }

        // GET api/astronaut
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Astronaut>>> GetAstronauts()
        {
            return await _db.Astronauts.Include(astronauts => astronauts.Superpower).ToListAsync();
        }

        // GET api/astronaut/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Astronaut>> GetAstronaut(int id)
        {
            //if (id == 0)
            //{
            //    return BadRequest();
            //}
            var astronaut = await _db.Astronauts.FindAsync(id);

            if (astronaut == null)
            {
                return NotFound();
            }

            return astronaut;
        }

        // POST: api/astronaut
        [HttpPost]
        public async Task<ActionResult<Astronaut>> PostAstronaut(Astronaut astronaut)
        {
            if (!AstronautExists(astronaut.Id))
            {
                _db.Astronauts.Add(astronaut);
                await _db.SaveChangesAsync();

                return CreatedAtAction("GetAstronaut", new { id = astronaut.Id }, astronaut);
            }
            else
            {
                return UnprocessableEntity();
            }
        }

        private bool AstronautExists(int id)
        {
            return _db.Astronauts.Any(x => x.Id == id);
        }

        // PUT api/astronaut/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAstronaut(int id, Astronaut astronaut)
        {
            if (id != astronaut.Id)
            {
                return BadRequest();
            }

            _db.Entry(astronaut).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AstronautExists(id))
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

        // DELETE api/astronaut/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAstronaut(int id)
        {
            var astronaut = await _db.Astronauts.FindAsync(id);
            if (astronaut == null)
            {
                return NotFound();
            }

            _db.Astronauts.Remove(astronaut);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
