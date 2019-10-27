using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Benefits.Controllers
{
    public class LoginController : Controller
    {
        //TODO: Autenticação do cliente
        //TODO: Autenticação da empresa

        public IActionResult LoginCliente()
        {
            return View();
        }

        public IActionResult LoginEmpresa()
        {
            return View();
        }
    }
}