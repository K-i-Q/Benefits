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
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Home", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            var usuarioAuxiliar = _usuarioDAO.BuscarPorEmail(usuario.Email);
            if (usuario.Email == null || usuario.Senha == null)
            {
                return View();
            }
            var signInResult = await _signInManager.PasswordSignInAsync(usuario.Email, usuario.Senha, true, lockoutOnFailure: false);
            if (usuarioAuxiliar != null)
            {

                if (signInResult.Succeeded)
                {
                    if (usuarioAuxiliar.Tipo)
                    {
                        //empresa[Tipo: true]
                        Empresa empresa = new Empresa();
                        empresa = _empresaDAO.BuscarPorIdentificador(usuarioAuxiliar.Identificador);
                        if (empresa != null)
                        {
                            return RedirectToAction("Index", "Empresa", empresa);
                        }
                    }
                    else
                    {
                        //cliente[Tipo: false]
                        Cliente cliente = new Cliente();
                        cliente = _clienteDAO.BuscarPorIdentificador(usuarioAuxiliar.Identificador);
                        if (cliente != null)
                        {
                            return RedirectToAction("Index", "Cliente", cliente);
                        }
                    }

                }
            }

            return View(usuario);
        }
    }
}