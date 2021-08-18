using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanceiroWeb.Controllers
{
    public class EmpresaController : PageBase
    {
        // GET: Empresa
        public void MontarTitulo(int tipo)
        {
            switch (tipo)
            {
                case 1:
                    ViewBag.Titulo = "Nova Empresa";
                    ViewBag.SubTitulo = "Aqui você cadastra suas empresas!";
                    break;

                case 2:
                    ViewBag.Titulo = "Alterar Empresa";
                    ViewBag.SubTitulo = "Aqui você altera suas empresas!";
                    break;

                case 3:
                    ViewBag.Titulo = "Consultar Empresa";
                    ViewBag.SubTitulo = "Aqui você consulta suas empresas!";
                    break;
            }
        }

        private void CarregarEmpresas()
        {
            EmpresaDAO objDao = new EmpresaDAO();
            ViewBag.listaEmpresa = objDao.ConsultarEmpresa(CodigoLogado);
        }
        // GET: Empresa
        public ActionResult Nova()
        {

            MontarTitulo(1);

            return View();
        }
        public ActionResult Alterar(int cod, string nome, string endereco, string telefone)
        {
            ViewBag.cod = cod;
            ViewBag.nome = nome;
            ViewBag.endereco = endereco;
            ViewBag.telefone = telefone;


            MontarTitulo(2);

            return View();
        }

        public ActionResult Consultar()
        {
            CarregarEmpresas();
            MontarTitulo(3);

            return View();
        }
        public ActionResult Gravar(int? cod, string nome_empresa, string telefone_empresa, string endereco_empresa, string btn)
        {
            string pagina = "";

            if (btn == "excluir")
            {
                EmpresaDAO objdao = new EmpresaDAO();
                try
                {
                    objdao.ExcluirEmpresa(Convert.ToInt32(cod));
                    ViewBag.Validar = 2;
                }
                catch
                {

                    ViewBag.Validar = -3;
                }
                finally
                {
                    MontarTitulo(3);
                    CarregarEmpresas();
                    pagina = "Consultar";
                }
            }
            else
            {
                if (nome_empresa == "" || telefone_empresa == "" || endereco_empresa == "")
                {
                    ViewBag.Validar = 0;
                }
                else
                {
                    tb_empresa objEmp = new tb_empresa();
                    EmpresaDAO objdao = new EmpresaDAO();

                    objEmp.id_usuario = CodigoLogado;
                    objEmp.nome_empresa = nome_empresa.Trim();
                    objEmp.telefone_empresa = telefone_empresa.Trim();
                    objEmp.endereco_empresa = endereco_empresa.Trim();

                    try
                    {
                        if (cod == null)
                        {
                            objdao.SalvarEmpresa(objEmp);
                        }
                        else
                        {
                            objEmp.id_empresa = Convert.ToInt32(cod);
                            objdao.AlterarEmpresa(objEmp);
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
                    ViewBag.nome = nome_empresa;

                    MontarTitulo(2);
                    pagina = "Alterar";

                }
            }

            return View(pagina);
            //return cod == null ? View("Nova") : View("Alterar");
        }
    }
}