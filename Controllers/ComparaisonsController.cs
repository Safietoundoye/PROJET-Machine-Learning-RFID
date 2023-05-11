using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJET.Data;
using PROJET.Models;

namespace PROJET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComparaisonsController : ControllerBase
    {
        private readonly PROJETContext _context;

        public ComparaisonsController(PROJETContext context)
        {
            _context = context;
        }

        // GET: api/Comparaisons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comparaison>>> GetComparaison()
        {
          if (_context.Comparaison == null)
          {
              return NotFound();
          }
            return await _context.Comparaison.ToListAsync();
        }

        // GET: api/Comparaisons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comparaison>> GetComparaison(int id)
        {
          if (_context.Comparaison == null)
          {
              return NotFound();
          }
            var comparaison = await _context.Comparaison.FindAsync(id);

            if (comparaison == null)
            {
                return NotFound();
            }

            return comparaison;
        }

        // PUT: api/Comparaisons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComparaison(int id, Comparaison comparaison)
        {
            if (id != comparaison.Id)
            {
                return BadRequest();
            }

            _context.Entry(comparaison).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComparaisonExists(id))
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

        // POST: api/Comparaisons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comparaison>> PostComparaison(Comparaison comparaison)
        {
          if (_context.Comparaison == null)
          {
              return Problem("Entity set 'PROJETContext.Comparaison'  is null.");
          }
            _context.Comparaison.Add(comparaison);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComparaison", new { id = comparaison.Id }, comparaison);
        }

        // DELETE: api/Comparaisons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComparaison(int id)
        {
            if (_context.Comparaison == null)
            {
                return NotFound();
            }
            var comparaison = await _context.Comparaison.FindAsync(id);
            if (comparaison == null)
            {
                return NotFound();
            }

            _context.Comparaison.Remove(comparaison);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComparaisonExists(int id)
        {
            return (_context.Comparaison?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
