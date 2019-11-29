using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Planos")]
    public class Plano
    {
        [Key]
        public int PlanoId { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public Empresa Empresa { get; set; }
        public int Nivel { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\nNome: " + Nome);
            sb.Append("\nDescrição: " + Descricao);
            sb.Append("\nPreco: " + Preco);

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            Plano p = (Plano)obj;

            return p.PlanoId == PlanoId;
        }
    }
}
