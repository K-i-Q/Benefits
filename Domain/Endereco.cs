using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Enderecos")]
    public class Endereco
    {
        [Key]
        public long EnderecoId { get; set; }
        [Display(Name = "Rua:")]
        public string Address { get; set; }
        [Display(Name = "CEP:")]
        public string Code { get; set; }
        [Display(Name = "Bairro:")]
        public string District { get; set; }
        [Display(Name = "Cidade:")]
        public string City { get; set; }
        [Display(Name = "Estado:")]
        public string State { get; set; }
        public DateTime CriadoEm { get; set; }
        public Endereco()
        {
            CriadoEm = DateTime.Now;
        }
    }
}
