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
        public long ClienteId { get; set; }
        public string Nome { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public string Telefone { get; set; }
        [Display(Name = "Gênero")]
        public string Genero { get; set; }
        [Display(Name = "Endereço")]
        public Endereco Endereco { get; set; }
        public DateTime CadastradoEm { get; set; }

        public Cliente()
        {
            CadastradoEm = DateTime.Now;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[Nome > " + Nome);
            sb.Append(", Email > " + Email);
            sb.Append(", Telefone > " + Telefone);
            sb.Append(", Genero > " + Genero+"]");
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            Cliente c = (Cliente)obj;
            return c.ClienteId == ClienteId;
        }
    }
}
