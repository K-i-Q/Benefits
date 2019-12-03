﻿using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Benefits.Controllers
{
    public class ClienteController : Controller
    {

        private readonly EmpresaClienteDAO _empresaClienteDAO;
        private readonly ClienteDAO _clienteDAO;
        private readonly EmpresaDAO _empresaDAO;
        private readonly UsuarioDAO _usuarioDAO;
        private readonly UserManager<UsuarioLogado> _userManager;
        private readonly SignInManager<UsuarioLogado> _signInManager;

        public ClienteController(EmpresaClienteDAO empresaClienteDAO, EmpresaDAO empresaDAO, ClienteDAO clienteDAO, UsuarioDAO usuarioDAO, UserManager<UsuarioLogado> userManager, SignInManager<UsuarioLogado> signInManager)
        {
            _empresaClienteDAO = empresaClienteDAO;
            _empresaDAO = empresaDAO;
            _clienteDAO = clienteDAO;
            _userManager = userManager;
            _signInManager = signInManager;
            _usuarioDAO = usuarioDAO;
        }

        #region Navigation Views Crud
        public IActionResult Index(Cliente cliente)
        {
            return View(cliente);
        }
        public IActionResult Cadastrar()
        {
            Cliente cliente = new Cliente();
            if (TempData["Endereco"] != null)
            {
                string resultado = TempData["Endereco"].ToString();
                Endereco endereco = JsonConvert.DeserializeObject<Endereco>(resultado);
                cliente.Endereco = endereco;
            }
            return View(cliente);
        }
        public IActionResult Editar(int id)
        {
            return View(_clienteDAO.BuscarPorId(id));
        }
        public IActionResult Excluir(int id)
        {
            return View(_clienteDAO.BuscarPorId(id));
        }
        #endregion

        #region Consumo de API
        [HttpPost]
        public IActionResult BuscarCep(Cliente cliente)
        {
            string url = "http://apps.widenet.com.br/busca-cep/api/cep/" + cliente.Endereco.Code + ".json";
            WebClient client = new WebClient();
            TempData["Endereco"] = client.DownloadString(url);
            return RedirectToAction(nameof(Cadastrar));
        }
        #endregion

        #region Navigation Views

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
        //[HttpPost]
        //public IActionResult Cadastrar(Cliente cliente)
        //{
        //TODO: validar campos
        //TODO: Não deixar cadastrar clientes iguais
        //if (_clienteDAO.Cadastrar(cliente))
        //{
        //return RedirectToAction("Index", cliente);
        //}
        //return View(cliente);
        //}
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

        #region EMRPESAS

        public IActionResult Empresas()
        {
            return View(_empresaDAO.ListarTodos());
        }


        public IActionResult EmpresaParceria(int? id)
        {
            TempData["id"] = id;
            return View();
        }
        [HttpPost]
        public IActionResult EmpresaParceria(EmpresaCliente empresaCliente)
        {
            try
            {
                int idEmpresa = Convert.ToInt32(TempData["id"].ToString());
                empresaCliente.Empresa = _empresaDAO.BuscarPorId(idEmpresa);
                //TODO: MEU ID... FUNC PARA PEGAR.
                empresaCliente.Cliente = _clienteDAO.BuscarPorId(1);
                _empresaClienteDAO.Cadastrar(empresaCliente);
                return RedirectToAction("empresas");
            }
            catch (System.Exception)
            {
                return View(empresaCliente);
                throw;
            }
        }

        public IActionResult EmpresaParceriasMinhas()
        {
            //todo: int? id
            //TODO: ALTERAR PARA ListarTodosPorCliente, QUANDO FIZER FUNÇAO DA PESSOA ON.
            return View(_empresaClienteDAO.ListarTodos());
        }















        #endregion

        [HttpPost]
        public async Task<IActionResult> Cadastrar(Cliente cliente, string Senha, string ConfirmacaoSenha)
        {
            if (cliente == null)
            {
                return View();
            }
            if (Senha == null || ConfirmacaoSenha == null)
            {
                return View(cliente);
            }
            if (!(Senha.Equals(ConfirmacaoSenha)))
            {
                return View(cliente);
            }
            if (ModelState.IsValid)
            {
                //Criar um objeto do UsuarioLogado e passar                 
                //obrigatoriamente o Email e UserName
                Usuario usuario = new Usuario();
                UsuarioLogado usuarioLogado = new UsuarioLogado
                {
                    Email = cliente.Email,
                    UserName = cliente.Email
                };

                usuario.Email = cliente.Email;
                usuario.Senha = Senha;
                usuario.ConfirmacaoSenha = ConfirmacaoSenha;
                usuario.Tipo = false;//[Tipo: false == Cliente]
                usuario.Identificador = cliente.Identificador;
                if (_usuarioDAO.Cadastrar(usuario))
                {
                    IdentityResult result = await _userManager.
                    CreateAsync(usuarioLogado, usuario.Senha);
                    //Testar o resultado do cadastro
                    if (result.Succeeded)
                    {
                        //Logar o usuário no sistema
                        await _signInManager.SignInAsync(usuarioLogado,
                            isPersistent: false);
                        if (_clienteDAO.Cadastrar(cliente))
                        {
                            return RedirectToAction("Index", cliente);
                        }
                        ModelState.AddModelError("", "Este e-mail já está sendo utilizado!");
                    }
                    AdicionarErros(result);
                }
                //Cadastra o usuário na tabela do Identity
            }
            return View(cliente);
        }
        private void AdicionarErros(IdentityResult result)
        {
            foreach (var erro in result.Errors)
            {
                ModelState.AddModelError
                    ("", erro.Description);
            }
        }


    }

}