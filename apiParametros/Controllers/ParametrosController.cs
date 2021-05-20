using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiParametros.Context;
using apiParametros.Models;

namespace apiParametros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametrosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ParametrosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Parametros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parametros>>> GetREGISTRO_PARAMETROS()
        {
            return await _context.REGISTRO_PARAMETROS.ToListAsync();
        }

        // GET: api/Parametros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parametros>> GetParametros(int id)
        {
            var parametros = await _context.REGISTRO_PARAMETROS.FindAsync(id);

            if (parametros == null)
            {
                return NotFound();
            }

            return parametros;
        }

        // PUT: api/Parametros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParametros(int id, Parametros parametros)
        {
            if (id != parametros.ID)
            {
                return BadRequest();
            }

            _context.Entry(parametros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParametrosExists(id))
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

        // POST: api/Parametros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Parametros>> PostParametros(Parametros parametros)
        {
            _context.REGISTRO_PARAMETROS.Add(parametros);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParametros", new { id = parametros.ID }, parametros);
        }

        // DELETE: api/Parametros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParametros(int id)
        {
            var parametros = await _context.REGISTRO_PARAMETROS.FindAsync(id);
            if (parametros == null)
            {
                return NotFound();
            }

            _context.REGISTRO_PARAMETROS.Remove(parametros);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParametrosExists(int id)
        {
            return _context.REGISTRO_PARAMETROS.Any(e => e.ID == id);
        }
    }
}
