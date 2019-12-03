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

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Telefone { get; set; }

        public Endereco Endereco { get; set; }
        public string Identificador { get; set; }
        public DateTime CadastradoEm { get; set; }


        public Cliente()
        {
            CadastradoEm = DateTime.Now;
            Identificador = Guid.NewGuid().ToString();
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
