using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Benefits.Models;
using Microsoft.AspNetCore.Mvc;

namespace Benefits.Controllers
{
    public class EmpresaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}