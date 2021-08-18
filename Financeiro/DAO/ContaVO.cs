using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ContaVO
    {
        public int idConta { get; set; }

        
        public string Agencia { get; set; }

        public string Numero { get; set; }

        public string Banco { get; set; }

        public int CodBanco { get; set; }

        public Decimal Saldo { get; set; }

        public bool Status { get; set; }
    }
}
