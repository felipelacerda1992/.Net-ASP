using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ContaDAO
    {
        public void SalvarConta(tb_conta objConta)
        {
            banco objbanco = new banco();
            objbanco.AddTotb_conta(objConta);
            objbanco.SaveChanges();
        }

        public List<tb_conta> ConsultarConta(int codLogado)
        {
            banco objbanco = new banco();

            List<tb_conta> listaConta = objbanco.tb_conta.Where(con => con.id_usuario == codLogado).ToList();

            return listaConta;
        }

        public List<tb_conta> ConsultarContaAtiva(int codLogado)
        {
            banco objbanco = new banco();

            List<tb_conta> listaConta = objbanco.tb_conta.Where(con => con.id_usuario == codLogado && con.status_conta == true).ToList();

            return listaConta;
        }

        public void AlterarConta(tb_conta objConta)
        {
            banco objbanco = new banco();

            tb_conta objResgate = objbanco.tb_conta.Where(con => con.id_conta == objConta.id_conta).FirstOrDefault();

            objResgate.numero_conta = objConta.numero_conta;
            objResgate.saldo_conta = objConta.saldo_conta;
            objResgate.agencia_conta = objConta.agencia_conta;
            objResgate.status_conta = objConta.status_conta;

            objbanco.SaveChanges();
        }

        public void ExcluirConta(int codConta)
        {
            banco objbanco = new banco();

            tb_conta objResgate = objbanco.tb_conta.Where(con => con.id_conta == codConta).FirstOrDefault();

            objbanco.DeleteObject(objResgate);

            objbanco.SaveChanges();
        }

        public List<ContaVO> ListarConta(int codLogado)
        {
            banco objbanco = new banco();

            List<ContaVO> listaRetorno = new List<ContaVO>();
            List<tb_conta> listaConsulta = new List<tb_conta>();

            listaConsulta = objbanco.tb_conta.Include("tb_banco").Where(conta => conta.id_usuario == codLogado).ToList();

            for (int i = 0; i < listaConsulta.Count; i++)
            {
                ContaVO vo = new ContaVO();
                vo.Agencia = listaConsulta[i].agencia_conta;
                vo.Numero = listaConsulta[i].numero_conta;
                vo.Banco = listaConsulta[i].tb_banco.nome_banco;
                vo.CodBanco = listaConsulta[i].id_banco;
                vo.Saldo = listaConsulta[i].saldo_conta;
                vo.idConta = listaConsulta[i].id_conta;
                vo.Status = listaConsulta[i].status_conta;

                listaRetorno.Add(vo);
            }

            return listaRetorno;
        }
    }
}
