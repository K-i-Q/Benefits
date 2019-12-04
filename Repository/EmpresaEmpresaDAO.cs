using Domain;
using Microsoft.EntityFrameworkCore;
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
                return _context.EmpresaEmpresas.Include(x => x.EmpresaUm).Include(x => x.EmpresaDois).FirstOrDefault(x => x.EmpresaEmpresaId == id);
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
            return _context.EmpresaEmpresas.Include(x=>x.EmpresaUm).Include(x=>x.EmpresaDois).ToList();
        }

        public List<EmpresaEmpresa> ListarTodosComEmail(string email)
        {
            return _context.EmpresaEmpresas.Include(x => x.EmpresaUm).Include(x => x.EmpresaDois).Where(x=> x.EmpresaUm.Email.Equals(email)).ToList();
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
