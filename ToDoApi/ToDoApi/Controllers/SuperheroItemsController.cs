using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperheroApi.Models;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [Route("api/SuperheroItems")]
    [ApiController]
    public class SuperheroItemsController : ControllerBase
    {
        private readonly SuperheroContext _context;

        public SuperheroItemsController(SuperheroContext context)
        {
            _context = context;
        }
        


        // GET: api/PowerStats/5
        [HttpGet("{id}/Powerstats")]
        public async Task<ActionResult<PowerstatsDTO>> GetSuperheroPowerstats(int id)
        {
            var superheroItem = await _context.SuperheroItems.Include(i => i.powerstats)
                .Where(i => i.id == id).Select(i =>
                new PowerstatsDTO
                {
                    response = i.response,
                    id = i.id,
                    name = i.name,
                    intelligence = i.powerstats.intelligence,
                    strength = i.powerstats.strength,
                    speed = i.powerstats.speed,
                    durability = i.powerstats.durability,
                    power = i.powerstats.power,
                    combat = i.powerstats.combat
                }).FirstOrDefaultAsync();

            if (superheroItem == null)
            {
                return NotFound();
            }

            return superheroItem;
        }

        // GET: api/SuperheroItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuperheroItem>>> GetSuperheroItems()
        {
            return await _context.SuperheroItems.ToListAsync();
        }

        [HttpGet("search/{name}")]
        public async Task<ActionResult<ExperimentAnon>> GetSuperheroItemByName(string name)
        {
            ExperimentAnon ea = new ExperimentAnon();

            var superHeroList = await _context.SuperheroItems
                .Include(i => i.powerstats)
                .Include(i => i.appearance)
                .Include(i => i.biography)
                .Include(i => i.connections)
                .Include(i => i.image)
                .Include(i => i.work)
                .Where(i => i.name.Contains(name)).ToListAsync();

            if (superHeroList == null || superHeroList.Count < 0)
            {
                return NotFound();
            }

            ea.response = superHeroList[0].response;
            ea.resultsfor = superHeroList[0].name;
            ea.results = new List<SuperheroItem>();
            foreach (var item in superHeroList)
            {
                ea.results.Add(item);
            }
            
            return ea;
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
