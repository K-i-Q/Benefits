using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class PlanoDAO : IRepository<Plano>
    {
        private readonly Context _context;
        public PlanoDAO(Context context)
        {
            _context = context;
        }

        public Plano BuscarPorId(int? id)
        {
            try
            {
                return _context.Planos.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Cadastrar(Plano plano)
        {
            try
            {
                _context.Planos.Add(plano);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Editar(Plano plano)
        {
            try
            {
                _context.Planos.Update(plano);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Plano> ListarTodos()
        {
            return _context.Planos.ToList();
        }

        public bool Remover(Plano plano)
        {
            try
            {
                _context.Planos.Remove(plano);
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
