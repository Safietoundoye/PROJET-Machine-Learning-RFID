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
    public class SauvegardesController : ControllerBase
    {
        private readonly PROJETContext _context;

        public SauvegardesController(PROJETContext context)
        {
            _context = context;
        }

        // GET: api/Sauvegardes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sauvegarde>>> GetSauvegarde()
        {
          if (_context.Sauvegarde == null)
          {
              return NotFound();
          }
            return await _context.Sauvegarde.ToListAsync();
        }

        // GET: api/Sauvegardes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sauvegarde>> GetSauvegarde(int id)
        {
          if (_context.Sauvegarde == null)
          {
              return NotFound();
          }
            var sauvegarde = await _context.Sauvegarde.FindAsync(id);

            if (sauvegarde == null)
            {
                return NotFound();
            }

            return sauvegarde;
        }

        // PUT: api/Sauvegardes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSauvegarde(int id, Sauvegarde sauvegarde)
        {
            if (id != sauvegarde.Id)
            {
                return BadRequest();
            }

            _context.Entry(sauvegarde).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SauvegardeExists(id))
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

        // POST: api/Sauvegardes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sauvegarde>> PostSauvegarde(Sauvegarde sauvegarde)
        {
          if (_context.Sauvegarde == null)
          {
              return Problem("Entity set 'PROJETContext.Sauvegarde'  is null.");
          }
            _context.Sauvegarde.Add(sauvegarde);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSauvegarde", new { id = sauvegarde.Id }, sauvegarde);
        }

        // DELETE: api/Sauvegardes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSauvegarde(int id)
        {
            if (_context.Sauvegarde == null)
            {
                return NotFound();
            }
            var sauvegarde = await _context.Sauvegarde.FindAsync(id);
            if (sauvegarde == null)
            {
                return NotFound();
            }

            _context.Sauvegarde.Remove(sauvegarde);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SauvegardeExists(int id)
        {
            return (_context.Sauvegarde?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
