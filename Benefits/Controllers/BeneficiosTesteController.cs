using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using Repository;

namespace Benefits.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiosTesteController : ControllerBase
    {
        private readonly Context _context;

        public BeneficiosTesteController(Context context)
        {
            _context = context;
        }

        // GET: api/BeneficiosTeste
        [HttpGet]
        public IEnumerable<Beneficio> GetBeneficios()
        {
            return _context.Beneficios.ToList();
        }

        // GET: api/BeneficiosTeste/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBeneficio([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var beneficio = await _context.Beneficios.FindAsync(id);

            if (beneficio == null)
            {
                return NotFound();
            }

            return Ok(beneficio);
        }

        // PUT: api/BeneficiosTeste/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeneficio([FromRoute] int id, [FromBody] Beneficio beneficio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != beneficio.BeneficioId)
            {
                return BadRequest();
            }

            _context.Entry(beneficio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeneficioExists(id))
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

        // POST: api/BeneficiosTeste
        [HttpPost]
        public async Task<IActionResult> PostBeneficio([FromBody] Beneficio beneficio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Beneficios.Add(beneficio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBeneficio", new { id = beneficio.BeneficioId }, beneficio);
        }

        // DELETE: api/BeneficiosTeste/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeneficio([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var beneficio = await _context.Beneficios.FindAsync(id);
            if (beneficio == null)
            {
                return NotFound();
            }

            _context.Beneficios.Remove(beneficio);
            await _context.SaveChangesAsync();

            return Ok(beneficio);
        }

        private bool BeneficioExists(int id)
        {
            return _context.Beneficios.Any(e => e.BeneficioId == id);
        }
    }
}