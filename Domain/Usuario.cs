using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Display(Name ="E-mail: ")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name ="Senha: ")]
        public string Senha { get; set; }

        [Display(Name ="Confirmação da senha: ")]
        [NotMapped]
        [Compare("Senha",ErrorMessage ="Senhas não batem")]
        public string  ConfirmacaoSenha { get; set; }

        [Display(Name ="Eu sou...")]
        public bool Tipo { get; set; }

        public string Identificador { get; set; }


    }
}
