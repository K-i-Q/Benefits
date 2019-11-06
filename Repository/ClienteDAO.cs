using Domain;
using Repository;
using System.Collections.Generic;

namespace Repository
{
    public class ClienteDAO
    {
        private readonly Context _context;

        public ClienteDAO(Context context)
        {
            _context = context;
        }

        public void CadastrarCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void EditarCliente(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public void ExcluirCliente(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

        public Cliente BuscarClientePorId(long id) => _context.Clientes.Find(id);

    }
}
