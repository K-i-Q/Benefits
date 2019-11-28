using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Empresas")]
    public class Empresa
    {
        [Key]
        public long EmpresaId { get; set; }
        [Display(Name ="CNPJ")]
        public string Cnpj { get; set; }
        [Display(Name = "Razão Social")]
        public string Razao { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        [Display(Name = "Endereço")]
        public Endereco Endereco { get; set; }
        public DateTime CriadaEm { get; set; }

        public Empresa()
        {
            CriadaEm = DateTime.Now;
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
