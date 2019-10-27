using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Benefits.DAL;
using Benefits.Models;
using Microsoft.AspNetCore.Mvc;

namespace Benefits.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteDAO _clienteDAO;
        public ClienteController(ClienteDAO clienteDAO)
        {
            _clienteDAO = clienteDAO;
        }
        #region Navigation Views
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Perfil()
        {
            return View();
        }
        public IActionResult Empresas()
        {
            return View();
        }
        public IActionResult Parceiros()
        {
            return View();
        }
        public IActionResult Beneficios()
        {
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        #endregion

        #region Crud Actions
        [HttpPost]
        public IActionResult Cadastrar(Cliente cliente)
        {
            _clienteDAO.CadastrarCliente(cliente);
            return RedirectToAction("Index");
        }

        #endregion
    }
}