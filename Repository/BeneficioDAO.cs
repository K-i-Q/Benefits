using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class BeneficioDAO : IRepository<Beneficio>
    {
        private readonly Context _context;

        public BeneficioDAO(Context context)
        {
            _context = context;
        }

        public Beneficio BuscarPorId(int? id)
        {
            try
            {
                return _context.Beneficios.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Cadastrar(Beneficio beneficio)
        {
            try
            {
                _context.Beneficios.Add(beneficio);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Editar(Beneficio beneficio)
        {
            try
            {
                _context.Beneficios.Update(beneficio);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Beneficio> ListarTodos()
        {
            return _context.Beneficios.ToList();
        }

        public bool Remover(Beneficio beneficio)
        {
            try
            {
                _context.Beneficios.Remove(beneficio);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Beneficio ListarBeneficioPorEmpresa(int? id)
        {
            try
            {
                return _context.Beneficios.FirstOrDefault(x => x.Empresa.EmpresaId == id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
