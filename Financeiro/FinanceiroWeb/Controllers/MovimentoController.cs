using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanceiroWeb.Controllers
{
    public class MovimentoController : PageBase
    {
        // GET: Movimento
        public void MontarTitulo(int tipo)
        {
            switch (tipo)
            {
                case 1:
                    ViewBag.Titulo = "Novo Movimento";
                    ViewBag.SubTitulo = "Aqui você cadastra seus movimentos!";
                    break;

                

                case 2:
                    ViewBag.Titulo = "Consultar Movimento";
                    ViewBag.SubTitulo = "Aqui você consulta sesus movimentos!";
                    break;
            }
        }

        public ActionResult Nova()
        {
            CarregarConta();
            CarregarCategoria();
            CarregarEmpresa();
            MontarTitulo(1);

            return View();
        }

        public ActionResult Consultar()
        {
            MontarTitulo(2);
            return View();
        }

        public void CarregarConta()
        {
            ViewBag.listaContas = new ContaDAO().ListarConta(CodigoLogado);
        }
        public void CarregarCategoria()
        {
            ViewBag.listaCategorias = new CategoriaDAO().ConsultarCategoria(CodigoLogado);
        }
        public void CarregarEmpresa()
        {
            ViewBag.listaEmpresas = new EmpresaDAO().ConsultarEmpresa(CodigoLogado);
        }

        public ActionResult FiltrarMov(string tipo, string dtInicial, string dtFinal)
        {
            ViewBag.tipo_mov = tipo;
            ViewBag.DataInicial = dtInicial;
            ViewBag.DataFinal = dtFinal;

            if (tipo == "" || dtFinal == "" || dtInicial == "")
            {
                ViewBag.Validar = 0;
            }
            else
            {
                MovimentoDAO objdao = new MovimentoDAO();

                ViewBag.movimentos = objdao.ConsultarMovimento(CodigoLogado, Convert.ToInt16(tipo), Convert.ToDateTime(dtInicial), Convert.ToDateTime(dtFinal));

                
            }
            MontarTitulo(1);
            return View("Consultar");
        }
        public ActionResult Gravar(string tipo_mov, string data_mov, Decimal valor_mov, string obs_mov, string id_conta, string id_categoria, string id_empresa)
        {
            // string pagina = "";
            

            if (tipo_mov == "" || data_mov == "" || valor_mov == 0 || id_categoria == "" || id_conta == "" || id_empresa == "")
                {
                    ViewBag.Validar = 0;
                }
                else
                {
                    tb_movimento objMov = new tb_movimento();
                    MovimentoDAO objdao = new MovimentoDAO();

                    objMov.id_usuario = CodigoLogado;
                    objMov.data_movimento = Convert.ToDateTime(data_mov);
                    objMov.valor_movimento = valor_mov;
                    objMov.obs_movimento = obs_mov;
                    objMov.tipo_movimento = Convert.ToInt16(tipo_mov);
                    objMov.id_conta = Convert.ToInt32(id_conta);
                    objMov.id_empresa = Convert.ToInt32(id_empresa);
                    objMov.id_categoria = Convert.ToInt32(id_categoria);

                try
                    {
                        
                        objdao.SalvarMovimento(objMov);
                        
                        ViewBag.Validar = 1;
                    }
                    catch
                    {

                        ViewBag.Validar = -1;
                    }
                }

                MontarTitulo(2);
               // pagina = "Nova";

                CarregarConta();
                CarregarCategoria();
                CarregarEmpresa();

            return View("Nova");
        }

        
    }
}