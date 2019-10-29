using Benefits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benefits.DAL
{
    public class EmpresaDAO
    {
        private readonly Context _context;

        public EmpresaDAO(Context context)
        {
            _context = context;
        }

        public void CadastrarEmpresa(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            _context.SaveChanges();
        }

        public void ExcluirEmpresa(Empresa empresa)
        {
            _context.Empresas.Remove(empresa);
            _context.SaveChanges();
        }

        public void EditarEmpresa(Empresa empresa)
        {
            _context.Empresas.Update(empresa);
            _context.SaveChanges();
        }

        public Empresa BuscarEmpresaPorId(long id) => _context.Empresas.Find(id);
    }
}
