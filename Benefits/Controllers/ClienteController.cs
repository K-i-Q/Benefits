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
        public IActionResult Editar(long id)
        {
            return View(_clienteDAO.BuscarClientePorId(id));
        }
        public IActionResult Detalhes(long id)
        {
            return View(_clienteDAO.BuscarClientePorId(id));
        }
        #endregion

        #region Crud Actions
        [HttpPost]
        public IActionResult Cadastrar(Cliente cliente)
        {
            //TODO: validar campos
            //TODO: Não deixar cadastrar clientes iguais
            _clienteDAO.CadastrarCliente(cliente);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            _clienteDAO.EditarCliente(cliente);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Detalhes(Cliente cliente)
        {
            _clienteDAO.BuscarClientePorId(cliente.ClienteId);
            return RedirectToAction("Index");
        }

        #endregion
    }
}