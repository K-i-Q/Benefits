using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository;
using System.Net;

namespace Benefits.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteDAO _clienteDAO;
        public ClienteController(ClienteDAO clienteDAO)
        {
            _clienteDAO = clienteDAO;
        }

        #region Consumo de API
        [HttpPost]
        public IActionResult BuscarCep(Cliente cliente)
        {
            string url = "https://viacep.com.br/ws/" + cliente.Endereco.Cep + "/json/";
            WebClient client = new WebClient();
            string resultado = client.DownloadString(url);
            //Endereco endereco = JsonConvert.DeserializeObject<Endereco>(resultado);
            TempData["Endereco"] = resultado;
            return RedirectToAction(nameof(Cadastrar));
        }
        #endregion


        #region Navigation Views Crud
        public IActionResult Index(Cliente cliente)
        {
            return View(cliente);
        }
        public IActionResult Cadastrar()
        {
            Cliente cliente = new Cliente();
            if(TempData["Endereco"] != null)
            {
                string resultado = TempData["Endereco"].ToString();
                Endereco endereco = JsonConvert.DeserializeObject<Endereco>(resultado);
                cliente.Endereco = endereco;
            }
            return View(cliente);
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
            if (_clienteDAO.Cadastrar(cliente))
            {
                return RedirectToAction("Index", cliente);
            }
            return View(cliente);
        }
        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            _clienteDAO.Editar(cliente);
            return RedirectToAction("Index", cliente);
        }
        [HttpPost]
        public IActionResult Excluir(Cliente cliente)
        {
            _clienteDAO.Remover(_clienteDAO.BuscarPorId(cliente.ClienteId));
            return RedirectToAction("Index", cliente);
        }
        #endregion
    }
}