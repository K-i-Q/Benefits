using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Threading.Tasks;

namespace Benefits.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioDAO _usuarioDAO;
        //TODO: Autenticação do cliente
        //TODO: Autenticação da empresa
        public UsuarioController(UsuarioDAO usuarioDAO)
        {
            _usuarioDAO = usuarioDAO;
        }
        public async Task<IActionResult> LoginCliente()
        {
            return View();
        }
        
        public IActionResult LoginEmpresa()
        {
            return View();
        }
    }
}