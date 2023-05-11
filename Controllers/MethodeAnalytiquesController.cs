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
    public class MethodeAnalytiquesController : ControllerBase
    {
        private readonly PROJETContext _context;

        public MethodeAnalytiquesController(PROJETContext context)
        {
            _context = context;
        }

        // GET: api/MethodeAnalytiques
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MethodeAnalytique>>> GetMethodeAnalytique()
        {
          if (_context.MethodeAnalytique == null)
          {
              return NotFound();
          }
            return await _context.MethodeAnalytique.ToListAsync();
        }

        // GET: api/MethodeAnalytiques/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MethodeAnalytique>> GetMethodeAnalytique(int id)
        {
          if (_context.MethodeAnalytique == null)
          {
              return NotFound();
          }
            var methodeAnalytique = await _context.MethodeAnalytique.FindAsync(id);

            if (methodeAnalytique == null)
            {
                return NotFound();
            }

            return methodeAnalytique;
        }

        // PUT: api/MethodeAnalytiques/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMethodeAnalytique(int id, MethodeAnalytique methodeAnalytique)
        {
            if (id != methodeAnalytique.Id)
            {
                return BadRequest();
            }

            _context.Entry(methodeAnalytique).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MethodeAnalytiqueExists(id))
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

        // POST: api/MethodeAnalytiques
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MethodeAnalytique>> PostMethodeAnalytique(MethodeAnalytique methodeAnalytique)
        {
          if (_context.MethodeAnalytique == null)
          {
              return Problem("Entity set 'PROJETContext.MethodeAnalytique'  is null.");
          }
            _context.MethodeAnalytique.Add(methodeAnalytique);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMethodeAnalytique", new { id = methodeAnalytique.Id }, methodeAnalytique);
        }

        // DELETE: api/MethodeAnalytiques/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMethodeAnalytique(int id)
        {
            if (_context.MethodeAnalytique == null)
            {
                return NotFound();
            }
            var methodeAnalytique = await _context.MethodeAnalytique.FindAsync(id);
            if (methodeAnalytique == null)
            {
                return NotFound();
            }

            _context.MethodeAnalytique.Remove(methodeAnalytique);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MethodeAnalytiqueExists(int id)
        {
            return (_context.MethodeAnalytique?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
