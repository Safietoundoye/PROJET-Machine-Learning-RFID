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
    public class RésultatController : ControllerBase
    {
        private readonly PROJETContext _context;

        public RésultatController(PROJETContext context)
        {
            _context = context;
        }

        // GET: api/Résultat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Résultat>>> GetRésultat()
        {
          if (_context.Résultat == null)
          {
              return NotFound();
          }
            return await _context.Résultat.ToListAsync();
        }

        // GET: api/Résultat/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Résultat>> GetRésultat(int id)
        {
          if (_context.Résultat == null)
          {
              return NotFound();
          }
            var résultat = await _context.Résultat.FindAsync(id);

            if (résultat == null)
            {
                return NotFound();
            }

            return résultat;
        }

        // PUT: api/Résultat/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRésultat(int id, Résultat résultat)
        {
            if (id != résultat.Id)
            {
                return BadRequest();
            }

            _context.Entry(résultat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RésultatExists(id))
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

        // POST: api/Résultat
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Résultat>> PostRésultat(Résultat résultat)
        {
          if (_context.Résultat == null)
          {
              return Problem("Entity set 'PROJETContext.Résultat'  is null.");
          }
            _context.Résultat.Add(résultat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRésultat", new { id = résultat.Id }, résultat);
        }

        // DELETE: api/Résultat/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRésultat(int id)
        {
            if (_context.Résultat == null)
            {
                return NotFound();
            }
            var résultat = await _context.Résultat.FindAsync(id);
            if (résultat == null)
            {
                return NotFound();
            }

            _context.Résultat.Remove(résultat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RésultatExists(int id)
        {
            return (_context.Résultat?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
