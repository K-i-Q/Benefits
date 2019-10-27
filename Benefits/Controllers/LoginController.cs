using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Benefits.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LoginCliente()
        {
            return View();
        }
    }
}