using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO;
namespace FinanceiroWeb.Controllers
{
    public class UsuarioController : PageBase
    {
        // GET: Usuario
        public ActionResult Cadastro()
        {

            

            return View();
        }

        public ActionResult Finalizar(string nome, string email, string senha, string rsenha)
        {
            if (nome.Trim() == "" || email.Trim() == "" || senha.Trim() == "" || rsenha.Trim() == "")
            {
                ViewBag.Validar = 0;
            }
            else if (senha.Trim() != rsenha.Trim())
            {
                ViewBag.Validar = -3;
            }
            else
            {
                UsuarioDAO dao = new UsuarioDAO();
                tb_usuario objUsuario = new tb_usuario();

                objUsuario.nome_usuario = nome;
                objUsuario.email_usuario = email;
                objUsuario.senha_usuario = senha;
                objUsuario.data_cadastro = DateTime.Now;

                try
                {
                    dao.FinalizarCadastro(objUsuario);
                    ViewBag.Validar = 3; //sucesso
                }
                catch 
                {
                    ViewBag.Validar = -1;
                }
            }
            return View("Cadastro");
        }
        public ActionResult Login()
        {

            

            return View();
        }

        public ActionResult ValidarLogin(string email, string senha)
        {
            if (email.Trim() == "" || senha.Trim() == "")
            {
                ViewBag.Validar = 0;
            }
            else
            {
                UsuarioDAO objDao = new UsuarioDAO();

                int cod = objDao.ValidarLogin(senha, email);

                if (cod != -2)
                {
                    CodigoLogado = cod;
                    Response.Redirect("~/Movimento/Consultar");
                }
                else
                {
                    ViewBag.Validar = -2;
                }
            }
            return View("Login");
        }

        public ActionResult Deslogar()
        {
            CodigoLogado = 0;
            return View("Login");
        }

    }
}