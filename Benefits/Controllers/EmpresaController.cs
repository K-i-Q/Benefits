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
        public IActionResult Editar(long id)
        {
            return View(_empresaDAO.BuscarEmpresaPorId(id));
        }
        public IActionResult Excluir(long id)
        {
            return View(_empresaDAO.BuscarEmpresaPorId(id));
        }
        #endregion

        #region Crud Actions
        [HttpPost]
        public IActionResult Cadastrar(Empresa empresa)
        {
            _empresaDAO.CadastrarEmpresa(empresa);
            return RedirectToAction("Index", empresa);
        }

        [HttpPost]
        public IActionResult Editar(Empresa empresa)
        {
            _empresaDAO.EditarEmpresa(empresa);
            return RedirectToAction("Index", empresa);
        }
        [HttpPost]
        public IActionResult Excluir(Empresa empresa)
        {
            _empresaDAO.ExcluirEmpresa(_empresaDAO.BuscarEmpresaPorId(empresa.EmpresaId));
            return RedirectToAction("Index", empresa.EmpresaId);
        }

        #endregion
    }
}