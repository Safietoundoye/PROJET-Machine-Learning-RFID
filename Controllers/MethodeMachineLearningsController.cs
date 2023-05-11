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
    public class MethodeMachineLearningsController : ControllerBase
    {
        private readonly PROJETContext _context;

        public MethodeMachineLearningsController(PROJETContext context)
        {
            _context = context;
        }

        // GET: api/MethodeMachineLearnings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MethodeMachineLearning>>> GetMethodeMachineLearning()
        {
          if (_context.MethodeMachineLearning == null)
          {
              return NotFound();
          }
            return await _context.MethodeMachineLearning.ToListAsync();
        }

        // GET: api/MethodeMachineLearnings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MethodeMachineLearning>> GetMethodeMachineLearning(int id)
        {
          if (_context.MethodeMachineLearning == null)
          {
              return NotFound();
          }
            var methodeMachineLearning = await _context.MethodeMachineLearning.FindAsync(id);

            if (methodeMachineLearning == null)
            {
                return NotFound();
            }

            return methodeMachineLearning;
        }

        // PUT: api/MethodeMachineLearnings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMethodeMachineLearning(int id, MethodeMachineLearning methodeMachineLearning)
        {
            if (id != methodeMachineLearning.Id)
            {
                return BadRequest();
            }

            _context.Entry(methodeMachineLearning).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MethodeMachineLearningExists(id))
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

        // POST: api/MethodeMachineLearnings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MethodeMachineLearning>> PostMethodeMachineLearning(MethodeMachineLearning methodeMachineLearning)
        {
          if (_context.MethodeMachineLearning == null)
          {
              return Problem("Entity set 'PROJETContext.MethodeMachineLearning'  is null.");
          }
            _context.MethodeMachineLearning.Add(methodeMachineLearning);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMethodeMachineLearning", new { id = methodeMachineLearning.Id }, methodeMachineLearning);
        }

        // DELETE: api/MethodeMachineLearnings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMethodeMachineLearning(int id)
        {
            if (_context.MethodeMachineLearning == null)
            {
                return NotFound();
            }
            var methodeMachineLearning = await _context.MethodeMachineLearning.FindAsync(id);
            if (methodeMachineLearning == null)
            {
                return NotFound();
            }

            _context.MethodeMachineLearning.Remove(methodeMachineLearning);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MethodeMachineLearningExists(int id)
        {
            return (_context.MethodeMachineLearning?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
