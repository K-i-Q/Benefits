using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class UsuarioDAO : IRepository<Usuario>
    {
        private readonly Context _context;

        public UsuarioDAO(Context context)
        {
            _context = context;
        }

        public Usuario BuscarPorId(int? id)
        {
            try
            {
                return _context.Usuarios.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Cadastrar(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Editar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ListarTodos()
        {
            return _context.Usuarios.ToList();
        }

        public bool Remover(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario BuscarPorEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(usuario => usuario.Email.Equals(email));
        }
    }
}
