using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Empresas")]
    public class Empresa
    {
        [Key]
        public int EmpresaId { get; set; }

        [MinLength(5, ErrorMessage = "No mínimo 11 caracteres")]
        [MaxLength(100, ErrorMessage = "No máximo 11 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Empresa")]
        public string Razao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Telefone { get; set; }

        public string Identificador { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime CriadaEm { get; set; }
        public List<Beneficio> Beneficios { get; set; }


        public Empresa()
        {
            CriadaEm = DateTime.Now;
            Identificador = Guid.NewGuid().ToString();
        }

        public override bool Equals(object obj)
        {
            Empresa empresa = (Empresa)obj;
            return empresa.Cnpj == Cnpj;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[CNPJ > " + Cnpj);
            sb.Append(", Razão > " + Razao);
            sb.Append(", Email > " + Email);
            sb.Append(", Telefone > " + Telefone);
            sb.Append(", Criada em > " + CriadaEm+"]");
            return sb.ToString();
        }
    }
}
