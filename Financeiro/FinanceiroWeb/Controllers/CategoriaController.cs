using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FinanceiroWeb.Controllers
{
    public class CategoriaController : PageBase
    {
        public void MontarTitulo(int tipo)
        {
            switch (tipo)
            {
                case 1:
                    ViewBag.Titulo = "Nova Categoria";
                    ViewBag.SubTitulo = "Aqui você cadastra suas categorias!";
                    break;

                case 2:
                    ViewBag.Titulo = "Alterar Categoria";
                    ViewBag.SubTitulo = "Aqui você altera suas categorias!";
                    break;

                case 3:
                    ViewBag.Titulo = "Consultar Categoria";
                    ViewBag.SubTitulo = "Aqui você consulta suas categorias!";
                    break;
            }
        }

        private void CarregarCategorias()
        {
            CategoriaDAO objDao = new CategoriaDAO();
            ViewBag.listaCategoria = objDao.ConsultarCategoria(CodigoLogado);
        }

        // GET: Categoria
        public ActionResult Nova()
        {

            MontarTitulo(1);

            return View();
        }
        public ActionResult Alterar(int cod, string nome)
        {
            ViewBag.cod = cod;
            ViewBag.nome = nome;

            MontarTitulo(2);

            return View();
        }

        public ActionResult Consultar()
        {
            CarregarCategorias();
            MontarTitulo(3);

            return View();
        }
        public ActionResult Gravar(int? cod, string nome_categoria, string btn)
        {
            string pagina = "";
            if (btn == "excluir")
            {
                CategoriaDAO objdao = new CategoriaDAO();
                try
                {
                    objdao.ExcluirCategoria(Convert.ToInt32(cod));
                    ViewBag.Validar = 2;
                }
                catch 
                {

                    ViewBag.Validar = -3;
                }
                finally
                {
                    MontarTitulo(3);
                    CarregarCategorias();
                    pagina = "Consultar";
                }
            }
            else
            {
                if (nome_categoria == "")
                {
                    ViewBag.Validar = 0;
                }
                else
                {
                    tb_categoria objCat = new tb_categoria();
                    CategoriaDAO objdao = new CategoriaDAO();

                    objCat.id_usuario = CodigoLogado;
                    objCat.nome_categoria = nome_categoria.Trim();

                    try
                    {
                        if (cod == null)
                        {
                            objdao.SalvarCategoria(objCat);
                        }
                        else
                        {
                            objCat.id_categoria = Convert.ToInt32(cod);
                            objdao.AlterarCategoria(objCat);
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
                    ViewBag.nome = nome_categoria;

                    MontarTitulo(2);
                    pagina = "Alterar";

                }
               
                //return cod == null ? View("Nova") : View("Alterar");
            }
            return View(pagina);
        }
    }
}