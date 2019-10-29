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
        #region Navigation Views Crud
        public IActionResult Index(Cliente cliente)
        {
            return View(cliente);
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        public IActionResult Editar(long id)
        {
            return View(_clienteDAO.BuscarClientePorId(id));
        }
        public IActionResult Excluir(long id)
        {
            return View(_clienteDAO.BuscarClientePorId(id));
        }
        #endregion

        #region Navigation Views
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
        #endregion

        #region Crud Actions
        [HttpPost]
        public IActionResult Cadastrar(Cliente cliente)
        {
            //TODO: validar campos
            //TODO: Não deixar cadastrar clientes iguais
            _clienteDAO.CadastrarCliente(cliente);
            return RedirectToAction("Index", cliente);
        }
        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            _clienteDAO.EditarCliente(cliente);
            return RedirectToAction("Index", cliente);
        }
        [HttpPost]
        public IActionResult Excluir(Cliente cliente)
        {
            _clienteDAO.ExcluirCliente(_clienteDAO.BuscarClientePorId(cliente.ClienteId));
            return RedirectToAction("Index", cliente);
        }
        #endregion
    }
}