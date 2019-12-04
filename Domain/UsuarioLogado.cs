using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class UsuarioLogado : IdentityUser
    {
        public static implicit operator UserManager<object>(UsuarioLogado v)
        {
            throw new NotImplementedException();
        }
    }
}
