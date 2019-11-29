using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Domain;

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
        //-------------------------------

        //GET: /api/Beneficio/ListarTodos
        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult ListarTodos()
        {
            return Ok(_beneficioDAO.ListarTodos());
        }

        //GET: /api/Beneficio/BuscarPorId/2
        [HttpGet]
        [Route("BuscarPorId/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Beneficio b = _beneficioDAO.BuscarPorId(id);
            if (b != null)
            {
                return Ok(b);
            }
            return NotFound(new { msg = "Beneficio não encontrado!" });
        }

        //GET: /api/Produto/BuscaPorEmpresa/2
        [HttpGet]
        [Route("BuscaPorEmpresa/{id}")]
        public IActionResult BuscarPorCategoria([FromRoute] int id)
        {
            List<Beneficio> beneficio =
                _beneficioDAO.ListarPorCategoria(id);
            if (beneficio.Count > 0)
            {
                return Ok(beneficio);
            }
            return NotFound(new { msg = "Essa busca não encontrou nenhum resultado!" });
        }


        //-------------------------------
        // GET: api/BeneficioAPI
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BeneficioAPI/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BeneficioAPI
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/BeneficioAPI/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
