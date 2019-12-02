using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public Identificador Identificador { get; set; }
        public DateTime CadastradoEm { get; set; }


        public Cliente()
        {
            CadastradoEm = DateTime.Now;
            Identificador = new Identificador();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[Nome > " + Nome);
            sb.Append(", Email > " + Email);
            sb.Append(", Genero > " + Telefone+ "]");
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            Cliente c = (Cliente)obj;
            return c.ClienteId == ClienteId;
        }
    }
}
