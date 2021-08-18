using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAO
{
    public class MovimentoDAO
    {
        public void SalvarMovimento(tb_movimento objMov)
        {
            banco objbanco = new banco();

            using (TransactionScope tran = new TransactionScope())
            {
                objbanco.AddTotb_movimento(objMov);
                objbanco.SaveChanges();

                tb_conta objResgate = objbanco.tb_conta.Where(c => c.id_conta == objMov.id_conta).FirstOrDefault();

                if (objMov.tipo_movimento == 0)
                    objResgate.saldo_conta = objResgate.saldo_conta + objMov.valor_movimento;                
                else
                    objResgate.saldo_conta = objResgate.saldo_conta - objMov.valor_movimento;

                objbanco.SaveChanges();
                tran.Complete();
            }
            
        }

        public void SalvarTransferencia(int entrada, int saida, Decimal valor)
        {
            banco objbanco = new banco();

            using (TransactionScope tran = new TransactionScope())
            {
                tb_conta objContaOrigem = objbanco.tb_conta.Where(p => p.id_conta == saida).FirstOrDefault();
                tb_conta objContaDestino = objbanco.tb_conta.Where(p => p.id_conta == entrada).FirstOrDefault();

                objContaOrigem.saldo_conta -= valor;
                objbanco.SaveChanges();
                objContaDestino.saldo_conta += valor;
                objbanco.SaveChanges();

                tran.Complete();
            }
            

        }

        public List<MovimentoVO> ConsultarMovimento(int codLogado, int tipo, DateTime dtInicial, DateTime dtFinal)
        {
            banco objbanco = new banco();
            List<MovimentoVO> listaRetorno = new List<MovimentoVO>();
            List<tb_movimento> listaConsulta = new List<tb_movimento>();

            if (tipo == 2)
            {
                listaConsulta = objbanco.tb_movimento.Include("tb_categoria")
                                                     .Include("tb_empresa")
                                                     .Include("tb_conta.tb_banco")
                                                     .Where(mov => mov.id_usuario == codLogado
                                                     && mov.data_movimento >= dtInicial
                                                     && mov.data_movimento <= dtFinal).ToList();
            }
            else
            {
                listaConsulta = objbanco.tb_movimento.Include("tb_categoria")
                                                     .Include("tb_empresa")
                                                     .Include("tb_conta.tb_banco")
                                                     .Where(mov => mov.id_usuario == codLogado
                                                     && mov.data_movimento >= dtInicial
                                                     && mov.data_movimento <= dtFinal
                                                     && mov.tipo_movimento == tipo).ToList();
            }

            for (int i = 0; i < listaConsulta.Count; i++)
            {
                MovimentoVO objvo = new MovimentoVO();

                objvo.Agencia = listaConsulta[i].tb_conta.agencia_conta;
                objvo.Banco = listaConsulta[i].tb_conta.tb_banco.nome_banco;
                objvo.Categoria = listaConsulta[i].tb_categoria.nome_categoria;
                objvo.Conta = listaConsulta[i].tb_conta.numero_conta;
                objvo.Data = listaConsulta[i].data_movimento.ToShortDateString();
                objvo.Empresa = listaConsulta[i].tb_empresa.nome_empresa;
                objvo.Tipo = listaConsulta[i].tipo_movimento == 0 ? "Entrada" : "Saída";
                objvo.Valor = listaConsulta[i].valor_movimento;
                objvo.Observacao = listaConsulta[i].obs_movimento;

                listaRetorno.Add(objvo);
            }

            return listaRetorno;
        }

        
    }
}
