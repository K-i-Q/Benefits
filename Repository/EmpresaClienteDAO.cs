using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    class EmpresaClienteDAO : IRepository<EmpresaCliente>
    {
        private readonly Context _context;

        public EmpresaClienteDAO(Context context)
        {
            _context = context;
        }
        public EmpresaCliente BuscarPorId(int? id)
        {
            try
            {
                return _context.EmpresaClientes.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Cadastrar(EmpresaCliente empresaCliente)
        {
            try
            {
                _context.EmpresaClientes.Add(empresaCliente);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Editar(EmpresaCliente empresaCliente)
        {
            try
            {
                _context.EmpresaClientes.Update(empresaCliente);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EmpresaCliente> ListarTodos()
        {
            return _context.EmpresaClientes.ToList();
        }

        public bool Remover(EmpresaCliente empresaCliente)
        {
            try
            {
                _context.EmpresaClientes.Remove(empresaCliente);
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
