using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class MovimentoVO
    {

        public string Empresa { get; set; }
        public string Banco { get; set; }
        public string Conta { get; set; }
        public string Agencia { get; set; }
        public string Categoria { get; set; }
        public string Data { get; set; }
        public string Tipo { get; set; }

        public string Observacao { get; set; }
        public decimal Valor { get; set; }

    }
}
