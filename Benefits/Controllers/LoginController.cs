using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Benefits.Controllers
{
    public class LoginController : Controller
    {
        //TODO: Autenticação do cliente
        //TODO: Autenticação da empresa

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