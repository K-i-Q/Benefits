using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefits.Models
{
    [Table("Empresas")]
    public class Empresa
    {
        [Key]
        public long EmpresaId { get; set; }
        public string Cnpj { get; set; }
        public string Razao { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
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
