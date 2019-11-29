using Domain;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace Benefits.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly EmpresaDAO _empresaDAO;

        public EmpresaController(EmpresaDAO empresaDAO)
        {
            _empresaDAO = empresaDAO;
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
        public IActionResult Cadastrar(Empresa empresa)
        {
            _empresaDAO.Cadastrar(empresa);
            return RedirectToAction("Index", empresa);
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