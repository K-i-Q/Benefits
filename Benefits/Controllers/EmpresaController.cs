using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Benefits.DAL;
using Benefits.Models;
using Microsoft.AspNetCore.Mvc;

namespace Benefits.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly EmpresaDAO _empresaDAO;

        public EmpresaController(EmpresaDAO empresaDAO)
        {
            _empresaDAO = empresaDAO;
        }

        public IActionResult Index(Empresa empresa)
        {
            return View(empresa);
        }
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Empresa empresa)
        {
            _empresaDAO.CadastrarEmpresa(empresa);
            return RedirectToAction("Index", empresa);
        }
    }
}