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
    public class Histo_HparamController : ControllerBase
    {
        private readonly PROJETContext _context;

        public Histo_HparamController(PROJETContext context)
        {
            _context = context;
        }

        // GET: api/Histo_Hparam
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Histo_Hparam>>> GetHisto_Hparam()
        {
          if (_context.Histo_Hparam == null)
          {
              return NotFound();
          }
            return await _context.Histo_Hparam.ToListAsync();
        }

        // GET: api/Histo_Hparam/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Histo_Hparam>> GetHisto_Hparam(int id)
        {
          if (_context.Histo_Hparam == null)
          {
              return NotFound();
          }
            var histo_Hparam = await _context.Histo_Hparam.FindAsync(id);

            if (histo_Hparam == null)
            {
                return NotFound();
            }

            return histo_Hparam;
        }

        // PUT: api/Histo_Hparam/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHisto_Hparam(int id, Histo_Hparam histo_Hparam)
        {
            if (id != histo_Hparam.IdHParam)
            {
                return BadRequest();
            }

            _context.Entry(histo_Hparam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Histo_HparamExists(id))
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

        // POST: api/Histo_Hparam
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Histo_Hparam>> PostHisto_Hparam(Histo_Hparam histo_Hparam)
        {
          if (_context.Histo_Hparam == null)
          {
              return Problem("Entity set 'PROJETContext.Histo_Hparam'  is null.");
          }
            _context.Histo_Hparam.Add(histo_Hparam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHisto_Hparam", new { id = histo_Hparam.IdHParam }, histo_Hparam);
        }

        // DELETE: api/Histo_Hparam/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHisto_Hparam(int id)
        {
            if (_context.Histo_Hparam == null)
            {
                return NotFound();
            }
            var histo_Hparam = await _context.Histo_Hparam.FindAsync(id);
            if (histo_Hparam == null)
            {
                return NotFound();
            }

            _context.Histo_Hparam.Remove(histo_Hparam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Histo_HparamExists(int id)
        {
            return (_context.Histo_Hparam?.Any(e => e.IdHParam == id)).GetValueOrDefault();
        }
    }
}
