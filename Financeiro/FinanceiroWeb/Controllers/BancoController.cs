using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanceiroWeb.Controllers
{
    public class BancoController : PageBase
    {
        // GET: Banco
        public void MontarTitulo(int tipo)
        {
            switch (tipo)
            {
                case 1:
                    ViewBag.Titulo = "Novo Banco";
                    ViewBag.SubTitulo = "Aqui você cadastra suas bancos!";
                    break;

                case 2:
                    ViewBag.Titulo = "Alterar Banco";
                    ViewBag.SubTitulo = "Aqui você altera suas bancos!";
                    break;

                case 3:
                    ViewBag.Titulo = "Consultar Banco";
                    ViewBag.SubTitulo = "Aqui você consulta suas banco!";
                    break;
            }
        }
        private void CarregarBancos()
        {
            BancoDAO objDao = new BancoDAO();
            ViewBag.listaBanco = objDao.ConsultarBanco(CodigoLogado);
        }
        // GET: Empresa
        public ActionResult Nova()
        {

            MontarTitulo(1);

            return View();
        }
        public ActionResult Alterar(int cod, string codbanco, string nome)
        {
            ViewBag.cod = cod;
            ViewBag.codbanco = codbanco;
            ViewBag.nome = nome;

            MontarTitulo(2);

            return View();
        }

        public ActionResult Consultar()
        {
            CarregarBancos();
            MontarTitulo(3);

            return View();
        }
        public ActionResult Gravar(int? cod, string codigo_banco, string nome_banco, string btn)
        {
            string pagina = "";

            if (btn == "excluir")
            {
                BancoDAO objdao = new BancoDAO();
                try
                {
                    objdao.ExcluirBanco(Convert.ToInt32(cod));
                    ViewBag.Validar = 2;
                }
                catch
                {

                    ViewBag.Validar = -3;
                }
                finally
                {
                    MontarTitulo(3);
                    CarregarBancos();
                    pagina = "Consultar";
                }
            }
            else
            {
                if (nome_banco == "" || codigo_banco == "")
                {
                    ViewBag.Validar = 0;
                }
                else
                {
                    tb_banco objBanco = new tb_banco();
                    BancoDAO objdao = new BancoDAO();

                    objBanco.id_usuario = CodigoLogado;
                    objBanco.nome_banco = nome_banco.Trim();
                    objBanco.codigo_banco = codigo_banco.Trim();

                    try
                    {
                        if (cod == null)
                        {
                            objdao.SalvarBanco(objBanco);
                        }
                        else
                        {
                            objBanco.id_banco = Convert.ToInt32(cod);
                            objdao.AlterarBanco(objBanco);
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
                    ViewBag.cod = cod;
                    ViewBag.nome = nome_banco;
                    ViewBag.codbanco = codigo_banco;

                    MontarTitulo(2);
                    pagina = "Alterar";

                }
            }
            return View(pagina);
            
            //return cod == null ? View("Nova") : View("Alterar");
        }
    }
}