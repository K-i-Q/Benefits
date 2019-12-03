using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Threading.Tasks;

namespace Benefits.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly EmpresaDAO _empresaDAO;
        private readonly UserManager<UsuarioLogado> _userManager;
        private readonly SignInManager<UsuarioLogado> _signInManager;

        public EmpresaController(EmpresaDAO empresaDAO, UserManager<UsuarioLogado> userManager, SignInManager<UsuarioLogado> signInManager)
        {
            _empresaDAO = empresaDAO;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        #region Navigation Views Crud
        public IActionResult Index(Empresa empresa)
        {
            return View(empresa);
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            return View(_empresaDAO.BuscarPorId(id));
        }
        public IActionResult Excluir(int id)
        {
            return View(_empresaDAO.BuscarPorId(id));
        }
        #endregion

        #region Crud Actions
        [HttpPost]
        public async Task<IActionResult> Cadastrar(Empresa empresa, string Senha, string ConfirmacaoSenha)
        {
            if(empresa == null)
            {
                return View();
            }
            if(Senha == null || Senha == "")
            {
                return View(empresa);
            }
            if (ConfirmacaoSenha == null || ConfirmacaoSenha == "")
            {
                return View(empresa);
            }
            if (!(Senha.Equals(ConfirmacaoSenha)))
            {
                return View(empresa);
            }
            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario();
                UsuarioLogado usuarioLogado = new UsuarioLogado
                {
                    Email = empresa.Email,
                    UserName = empresa.Email
                };
                usuario.Email = empresa.Email;
                usuario.Senha = Senha;
                usuario.ConfirmacaoSenha = ConfirmacaoSenha;
                usuario.Tipo = true;//[Tipo: true == Empresa]

                IdentityResult result = await _userManager.
                    CreateAsync(usuarioLogado, usuario.Senha);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(usuarioLogado,
                        isPersistent: false);
                    if (_empresaDAO.Cadastrar(empresa))
                    {
                        return RedirectToAction("Index", empresa);
                    }
                    ModelState.AddModelError("", "Este e-mail já está sendo utilizado!");
                }
                AdicionarErros(result);
            }
            return View(empresa);
        }

        private void AdicionarErros(IdentityResult result)
        {
            foreach (var erro in result.Errors)
            {
                ModelState.AddModelError
                    ("", erro.Description);
            }
        }

        [HttpPost]
        public IActionResult Editar(Empresa empresa)
        {
            _empresaDAO.Editar(empresa);
            return RedirectToAction("Index", empresa);
        }
        [HttpPost]
        public IActionResult Excluir(Empresa empresa)
        {
            _empresaDAO.Remover(_empresaDAO.BuscarPorId(empresa.EmpresaId));
            return RedirectToAction("Index", empresa.EmpresaId);
        }

        #endregion
    }
}