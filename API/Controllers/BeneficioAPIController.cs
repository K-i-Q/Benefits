using System;
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
    [Route("api/beneficio")]
    [ApiController]
    public class BeneficioAPIController : ControllerBase
    {
        private readonly BeneficioDAO _beneficioDAO;
        public BeneficioAPIController(BeneficioDAO beneficioDAO)
        {
            _beneficioDAO = beneficioDAO;
        }

        //GET: /api/Beneficio/ListarTodos
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_beneficioDAO.ListarTodos());
        }

        //GET: /api/Beneficio/BuscarPorId/2
        [HttpGet]
        [Route("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Beneficio p = _beneficioDAO.BuscarPorId(id);
            if (p != null)
            {
                return Ok(p);
            }
            return NotFound(new { msg = "Beneficio não encontrado!" });
        }

        //[HttpPost]
        //[Route("Cadastrar")]
        //public IActionResult Cadastrar([FromBody]Beneficio b)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (_beneficioDAO.Cadastrar(b))
        //        {
        //            return Created("", b);
        //        }
        //        return Conflict(new { msg = "Esse beneficio já existe!" });
        //    }
        //    return BadRequest(ModelState);
        //}
    }
}