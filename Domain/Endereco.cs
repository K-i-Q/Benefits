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
        public string Logradouro { get; set; }
        [Display(Name = "CEP:")]
        public string Cep { get; set; }
        [Display(Name = "Bairro:")]
        public string Bairro { get; set; }
        [Display(Name = "Cidade:")]
        public string Localidade { get; set; }
        [Display(Name = "Estado:")]
        public string Uf { get; set; }
        public DateTime CriadoEm { get; set; }
        public Endereco()
        {
            CriadoEm = DateTime.Now;
        }
    }
}
