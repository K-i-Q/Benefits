using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Repository;

namespace Repository
{
    public class EmpresaDAO : IRepository<Empresa>
    {
        private readonly Context _context;

        public EmpresaDAO(Context context)
        {
            _context = context;
        }

        public bool Cadastrar(Empresa empresa)
        {
            try
            {
                _context.Empresas.Add(empresa);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Empresa> ListarTodos()
        {
            return _context.Empresas.ToList();
        }

        public Empresa BuscarPorId(int? id)
        {
            try
            {
                return _context.Empresas.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Remover(Empresa empresa)
        {
            try
            {
                _context.Empresas.Remove(empresa);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Editar(Empresa empresa)
        {
            try
            {
                _context.Empresas.Update(empresa);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Empresa BuscarPorIdentificador(string identificador)
        {
            try
            {
                return _context.Empresas.FirstOrDefault(identificadorTabela => identificadorTabela.Identificador == identificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
