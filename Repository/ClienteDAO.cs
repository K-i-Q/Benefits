using Domain;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class ClienteDAO : IRepository<Cliente>
    {
        private readonly Context _context;

        public ClienteDAO(Context context)
        {
            _context = context;
        }

        public bool Cadastrar(Cliente cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Cliente> ListarTodos()
        {
            return _context.Clientes.ToList();
        }

        public List<Beneficio> RetornarBeneficiosDeEmpresaId(int? id)
        {
            return _context.Beneficios.Include(x => x.Empresa).Where(x => x.Empresa.EmpresaId == id).ToList();
        }

        public Cliente BuscarPorId(int? id)
        {
            try
            {
                return _context.Clientes.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cliente BuscarPorEmail(string email)
        {
            try
            {
                return _context.Clientes.First(x=>x.Email.Equals(email));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Remover(Cliente cliente)
        {
            try
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool Editar(Cliente cliente)
        {
            try
            {
                _context.Clientes.Update(cliente);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Cliente BuscarPorIdentificador(string identificador)
        {
            try
            {
                return _context.Clientes.FirstOrDefault(cliente => cliente.Identificador == identificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
