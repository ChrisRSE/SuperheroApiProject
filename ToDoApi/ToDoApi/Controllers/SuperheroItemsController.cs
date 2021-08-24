using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperheroApi.Models;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroItemsController : ControllerBase
    {
        private readonly SuperheroContext _context;

        public SuperheroItemsController(SuperheroContext context)
        {
            _context = context;
        }

        // GET: api/SuperheroItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuperheroItem>>> GetSuperheroItems()
        {
            return await _context.SuperheroItems.ToListAsync();
        }

        // GET: api/SuperheroItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperheroItem>> GetSuperheroItem(int id)
        {
            var superheroItem = await _context.SuperheroItems.Include(i => i.powerstats)
                .Include(i => i.appearance)
                .Include(i => i.biography)
                .Include(i => i.connections)
                .Include(i => i.image)
                .Include(i => i.work)
                .Where(i => i.id == id).FirstOrDefaultAsync();

            if (superheroItem == null)
            {
                return NotFound();
            }

            return superheroItem;
        }

        // PUT: api/SuperheroItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuperheroItem(int id, SuperheroItem superheroItem)
        {
            if (id != superheroItem.id)
            {
                return BadRequest();
            }

            _context.Entry(superheroItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuperheroItemExists(id))
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

        // POST: api/SuperheroItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SuperheroItem>> PostSuperheroItem(SuperheroItem superheroItem)
        {
            _context.SuperheroItems.Add(superheroItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSuperheroItem", new { id = superheroItem.id }, superheroItem);
        }

        // DELETE: api/SuperheroItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuperheroItem(int id)
        {
            var superheroItem = await _context.SuperheroItems.FindAsync(id);
            if (superheroItem == null)
            {
                return NotFound();
            }

            _context.SuperheroItems.Remove(superheroItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuperheroItemExists(int id)
        {
            return _context.SuperheroItems.Any(e => e.id == id);
        }
    }
}
