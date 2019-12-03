﻿using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Threading.Tasks;

namespace Benefits.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly EmpresaEmpresaDAO _empresaEmpresaDAO;
        private readonly EmpresaClienteDAO _empresaClienteDAO;
        private readonly BeneficioDAO _beneficioDAO;
        private readonly EmpresaDAO _empresaDAO;
        private readonly UsuarioDAO _usuarioDAO;
        private readonly UserManager<UsuarioLogado> _userManager;
        private readonly SignInManager<UsuarioLogado> _signInManager;

        public EmpresaController(EmpresaEmpresaDAO empresaEmpresaDAO ,EmpresaClienteDAO empresaClienteDAO ,BeneficioDAO beneficioDAO ,EmpresaDAO empresaDAO, UsuarioDAO usuarioDAO, UserManager<UsuarioLogado> userManager, SignInManager<UsuarioLogado> signInManager)
        {
            _empresaClienteDAO = empresaClienteDAO;
            _empresaEmpresaDAO = empresaEmpresaDAO;
            _beneficioDAO = beneficioDAO;
            _empresaDAO = empresaDAO;
            _usuarioDAO = usuarioDAO;
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
        

        public IActionResult Parceiros()
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
            if (empresa == null)
            {
                return View();
            }
            if (Senha == null || Senha == "")
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
                usuario.Identificador = empresa.Identificador;
                if (_usuarioDAO.Cadastrar(usuario))
                {
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

        #region  EMPRESA CLIENTE
        //public IActionResult Clientes()
        //{
        //    return View(_empresaClienteDAO.ListarTodos());
        //}
        //public IActionResult ClientesCreate()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult ClientesCreate(Beneficio beneficio)
        //{
               
        //        //return RedirectToAction("BeneficiosView", beneficio);

        //    return View(beneficio);
        //}

        #endregion

        #region BENEFICIOS 
        public IActionResult Beneficios()
        {
            return View(_beneficioDAO.ListarTodosComEmpresa());
        }
        public IActionResult BeneficiosCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BeneficiosCreate(Beneficio beneficio)
        {
            if (_beneficioDAO.ValidaPorNome(beneficio))
            {
                //TODO: BUSCAR EMPRESA LOGADA.
                beneficio.Empresa = _empresaDAO.BuscarPorId(1);
                _beneficioDAO.Cadastrar(beneficio);
                return RedirectToAction("BeneficiosDetails", beneficio);
            }

            return View(beneficio);
        }
        public IActionResult BeneficiosEdit(int? id)
        {
            return View(_beneficioDAO.BuscarPorId(id));
        }
        [HttpPost]
        public IActionResult BeneficiosEdit(Beneficio beneficio)
        {
            _beneficioDAO.Editar(beneficio);
            return RedirectToAction("BeneficiosView", beneficio);
        }
        public IActionResult BeneficiosDetails(Beneficio beneficio)
        {
            return View(beneficio);
        }

        #endregion

    }
}