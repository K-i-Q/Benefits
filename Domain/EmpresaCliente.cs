using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("ClientesDaEmpresa")]
    public class EmpresaCliente
    {
        [Key]
        public int EmpresaClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public Empresa Empresa { get; set; }
        public Plano Plano { get; set; }
        public int Nivel{ get; set; }
        public DateTime ContratadaEm { get; set; }

        public EmpresaCliente()
        {
            ContratadaEm = DateTime.Now;
        }
    }
}
