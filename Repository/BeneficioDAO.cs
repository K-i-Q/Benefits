﻿using Domain;
using Microsoft.EntityFrameworkCore;
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
        public bool ValidaPorNome(Beneficio beneficio)
        {
            try
            {
                if (_context.Beneficios.FirstOrDefault(x => x.Nome.Equals(beneficio.Nome)) == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                return false;
                throw;
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
        public List<Beneficio> ListarTodosComEmpresa()
        {
            return _context.Beneficios.ToList();
        }
        public List<Beneficio> ListarTodosEmpresaId(int? id)
        {
            return _context.Beneficios.Include(x => x.Empresa).Where(x => x.Empresa.EmpresaId == id).ToList();
        }
        public List<Beneficio> ListarBeneficiosEmpresa(string email)
        {
            return _context.Beneficios.Where(x => x.Empresa.Email.Equals(email)).ToList();
        }


        public List<EmpresaEmpresa> ListarTodosBeneficiosEmpresa(int? id)
        {
            //return _context.Beneficios.Include(x => x.Empresa).ToList();
            return _context.EmpresaEmpresas.Include(x => x.EmpresaUm.Beneficios).Include(x => x.EmpresaDois.Beneficios).Where(x => x.EmpresaUm.EmpresaId == id).ToList();
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

        public List<Beneficio> BeneficiosTodasEmpresas(int? id)
        {
            //1
            //PEGAR TODOS ID DAS PARCEIRAS DA EMPRESA SELECIODA POR ID
            List<Beneficio> beneficiosGeral = new List<Beneficio>();
            List<int> idList = new List<int>();
            idList.Add(Convert.ToInt32(id));
            List<EmpresaEmpresa> recuperarTodos = _context.EmpresaEmpresas.Include(x => x.EmpresaDois).Include(x => x.EmpresaUm).ToList();
            int counttodos = _context.EmpresaEmpresas.Count();

            foreach (EmpresaEmpresa i in recuperarTodos)
            {
                if (id == i.EmpresaUm.EmpresaId)
                {
                    idList.Add(i.EmpresaDois.EmpresaId);
                }
            }
            //2
            //PERCORRE A LISTA DE ID E PERCORRE A LISTA DE BENEFICIOS COM ID DA LISTA, E ADD NA LISTA DE BENE NOVO.
            foreach (int i in idList)
            {
                foreach (Beneficio x in _context.Beneficios)
                {
                    if (i == x.Empresa.EmpresaId)
                    {
                        beneficiosGeral.Add(x);
                    }
                }
            }

            return beneficiosGeral;
        }

    }
}
