using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Identificadores")]
    public class Identificador
    {
        [Key]
        public int IdentificadorId { get; set; }
        public Guid Id { get; set; }

        public Identificador()
        {
            Id = Guid.NewGuid();
        }
    }
}
