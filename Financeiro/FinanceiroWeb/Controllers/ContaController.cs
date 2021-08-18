using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanceiroWeb.Controllers
{
    public class ContaController : PageBase
    {
        // GET: Conta
        public void MontarTitulo(int tipo)
        {
            switch (tipo)
            {
                case 1:
                    ViewBag.Titulo = "Nova Conta";
                    ViewBag.SubTitulo = "Aqui você cadastra suas contas!";
                    break;

                case 2:
                    ViewBag.Titulo = "Alterar Conta";
                    ViewBag.SubTitulo = "Aqui você altera suas contas!";
                    break;

                case 3:
                    ViewBag.Titulo = "Consultar Conta";
                    ViewBag.SubTitulo = "Aqui você consulta suas conta!";
                    break;
            }
        }

        // GET: Empresa
        public ActionResult Nova()
        {
            CarregarBanco();
            MontarTitulo(1);

            return View();
        }
        public ActionResult Alterar(int cod, int banco, string agencia, string numero, string saldo, string status)
        {
            ViewBag.cod = cod;
            ViewBag.banco = banco;
            ViewBag.agencia = agencia;
            ViewBag.numero = numero;
            ViewBag.saldo = saldo;
            ViewBag.status = status;
            CarregarBanco();
            MontarTitulo(2);

            return View();
        }

        public ActionResult Consultar()
        {
            CarregarConta();
            CarregarBanco();
            MontarTitulo(3);

            return View();
        }

        public void CarregarConta()
        {
            ViewBag.listarContas = new ContaDAO().ListarConta(CodigoLogado);
        }
        private void CarregarBanco()
        {
            BancoDAO objDao = new BancoDAO();
            ViewBag.listaBancos = objDao.ConsultarBanco(CodigoLogado);
            //ViewBag.listaBancos = new BancoDAO().ConsultarBanco(CodigoLogado);
        }
        public ActionResult Gravar(int? cod, string agencia_conta, string numero_conta, Decimal saldo_conta, int id_banco, string status_conta, string btn)
        {
            string pagina = "";
            if (btn == "excluir")
            {
                ContaDAO objdao = new ContaDAO();
                try
                {
                    objdao.ExcluirConta(Convert.ToInt32(cod));
                    ViewBag.Validar = 2;
                }
                catch (Exception)
                {
                    ViewBag.Validar = -3;
                }
                finally
                {
                    MontarTitulo(3);
                    CarregarConta();
                    pagina = "Consultar";
                }
            }
            else
            {
                if (agencia_conta == "" || numero_conta == "" || saldo_conta == 0)
                {
                    ViewBag.Validar = 0;
                }
                else
                {
                    tb_conta objConta = new tb_conta();
                    ContaDAO objdao = new ContaDAO();

                    objConta.id_usuario = CodigoLogado;
                    objConta.agencia_conta = agencia_conta.Trim();
                    objConta.numero_conta = numero_conta.Trim();
                    objConta.saldo_conta = saldo_conta;
                    objConta.id_banco = id_banco;
                    objConta.status_conta = status_conta == null ? false : true;

                    try
                    {
                        if (cod == null)
                        {
                            objdao.SalvarConta(objConta);
                        }
                        else
                        {
                            objConta.id_conta = Convert.ToInt32(cod);
                            objdao.AlterarConta(objConta);
                        }
                        ViewBag.Validar = 1;
                    }
                    catch
                    {

                        ViewBag.Validar = -1;
                    }
                }



                if (cod == null)
                {
                    MontarTitulo(1);
                    pagina = "Nova";
                }
                else
                {
                    MontarTitulo(2);
                    pagina = "Alterar";
                }
                CarregarBanco();
            }
            return View(pagina);

        }
    }
}