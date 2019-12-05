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
        private readonly EmpresaDAO _empresaDAO;
        private readonly ClienteDAO _clienteDAO;
        private readonly BeneficioDAO _beneficioDAO;
        public BeneficioAPIController(ClienteDAO clienteDAO, EmpresaDAO empresaDAO,BeneficioDAO beneficioDAO)
        {
            _clienteDAO = clienteDAO;
            _empresaDAO = empresaDAO;
            _beneficioDAO = beneficioDAO;
        }

        //GET: /api/Beneficio/ListarTodos
        [HttpGet("listarbeneficios")]
        public IActionResult ListarTodos()
        {
            return Ok(_beneficioDAO.ListarTodosComEmpresa());
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

        [HttpGet("listarempresas")]
        public IActionResult ListartodasEmpresas()
        {
            return Ok(_empresaDAO.ListarTodos());
        }

        [HttpGet("listarclientes")]
        public IActionResult ListarTodosClientes()
        {
            return Ok(_clienteDAO.ListarTodos());
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