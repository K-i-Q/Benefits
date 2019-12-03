using Domain;
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
