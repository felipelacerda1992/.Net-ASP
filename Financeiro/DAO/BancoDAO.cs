using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BancoDAO
    {
        public void SalvarBanco(tb_banco objBanco)
        {
            banco objbd = new banco();
            objbd.AddTotb_banco(objBanco);
            objbd.SaveChanges();
        }

        public List<tb_banco> ConsultarBanco(int codLogado)
        {
            banco objbanco = new banco();

            List<tb_banco> listaBanco = objbanco.tb_banco.Where(bc => bc.id_usuario == codLogado).ToList();

            return listaBanco;
        }

        public void AlterarBanco(tb_banco objBanco)
        {
            banco objbanco = new banco();

            tb_banco objResgate = objbanco.tb_banco.Where(bc => bc.id_banco == objBanco.id_banco).FirstOrDefault();

            objResgate.nome_banco = objBanco.nome_banco;
            objResgate.codigo_banco = objBanco.codigo_banco;

            objbanco.SaveChanges();
        }

        public void ExcluirBanco(int codBanco)
        {
            banco objbanco = new banco();

            tb_banco objResgate = objbanco.tb_banco.Where(cat => cat.id_banco == codBanco).FirstOrDefault();

            objbanco.DeleteObject(objResgate);

            objbanco.SaveChanges();
        }
    }
}
