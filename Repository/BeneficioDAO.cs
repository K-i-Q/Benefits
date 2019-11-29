using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class BeneficioDAO
    {
        private readonly Context _context;

        public BeneficioDAO(Context context)
        {
            _context = context;
        }
    }
}
