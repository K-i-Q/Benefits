using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Beneficios")]
    class Beneficio
    {
        [Key]
        public int BeneficioId { get; set; }
        public string Nome { get; set; }
        public int Nivel { get; set; }
        public string Descricao { get; set; }
        public DateTime CriadoEm { get; set; }
        public Empresa Empresa { get; set; }

        public Beneficio()
        {
            CriadoEm = DateTime.Now;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("________________________________________");
            sb.Append("\n| ");
            sb.Append("Nome: ");
            sb.Append(Nome);
            sb.Append("\n| ");
            sb.Append("Nivel: ");
            sb.Append(Nivel);
            sb.Append("\n| ");
            sb.Append("Descrição: ");
            sb.Append(Descricao);
            sb.Append("\n| ");
            sb.Append("Empresa: ");
            sb.Append(Empresa);
            sb.Append("\n| ");
            sb.Append("Cadastrado em: ");
            sb.Append(CriadoEm);
            sb.Append("\n| ");
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            Beneficio b = (Beneficio)obj;
            return BeneficioId == b.BeneficioId;
        }
    }
}
