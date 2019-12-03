using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
   public class EmpresaEmpresaDAO : IRepository<EmpresaEmpresa>
    {
        private readonly Context _context;

        public EmpresaEmpresaDAO(Context context)
        {
            _context = context;
        }

        public EmpresaEmpresa BuscarPorId(int? id)
        {
            try
            {
                return _context.EmpresaEmpresas.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Cadastrar(EmpresaEmpresa empresaEmpresa)
        {
            try
            {
                _context.EmpresaEmpresas.Add(empresaEmpresa);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Editar(EmpresaEmpresa empresaEmpresa)
        {
            try
            {
                _context.EmpresaEmpresas.Update(empresaEmpresa);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EmpresaEmpresa> ListarTodos()
        {
            return _context.EmpresaEmpresas.ToList();
        }

        public bool Remover(EmpresaEmpresa empresaEmpresa)
        {
            try
            {
                _context.EmpresaEmpresas.Remove(empresaEmpresa);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
