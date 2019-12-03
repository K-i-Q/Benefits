using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Threading.Tasks;

namespace Benefits.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioDAO _usuarioDAO;
        private readonly EmpresaDAO _empresaDAO;
        private readonly ClienteDAO _clienteDAO;
        private readonly UserManager<UsuarioLogado> _userManager;
        private readonly SignInManager<UsuarioLogado> _signInManager;
        //TODO: Autenticação do cliente
        //TODO: Autenticação da empresa
        public UsuarioController(UsuarioDAO usuarioDAO, ClienteDAO clienteDAO, EmpresaDAO empresaDAO, UserManager<UsuarioLogado> userManager, SignInManager<UsuarioLogado> signInManager)
        {
            _usuarioDAO = usuarioDAO;
            _empresaDAO = empresaDAO;
            _clienteDAO = clienteDAO;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            if(usuario.Email == null || usuario.Senha == null)
            {
                return View();
            }
            var signInResult = await _signInManager.PasswordSignInAsync(usuario.Email, usuario.Senha, true, lockoutOnFailure: false);

            if (signInResult.Succeeded)
            {
                if (usuario.Tipo)
                {
                    //empresa[Tipo: true]
                    Empresa empresa = new Empresa();
                    empresa = _empresaDAO.BuscarPorIdentificador(usuario.Identificador);
                    if(empresa != null)
                    {
                        RedirectToAction("Index",empresa);
                    }
                }
                else
                {
                    //cliente[Tipo: false]
                    Cliente cliente = new Cliente();
                    cliente = _clienteDAO.BuscarPorIdentificador(usuario.Identificador);
                    if(cliente != null)
                    {
                        RedirectToAction("Index", cliente);
                    }
                }

            }
            return View(usuario);
        }
    }
}