﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficioAPIController : ControllerBase
    {
        private readonly Context _context;

        public BeneficioAPIController(Context context)
        {
            _context = context;
        }

        // GET: api/BeneficioAPI
        [HttpGet]
        public IEnumerable<Beneficio> GetBeneficios()
        {
            return _context.Beneficios;
        }

        // GET: api/BeneficioAPI/5
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

        // PUT: api/BeneficioAPI/5
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

        // POST: api/BeneficioAPI
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

        // DELETE: api/BeneficioAPI/5
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