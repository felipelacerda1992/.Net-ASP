using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanceiroWeb
{
    public class PageBase : Controller
    {
        public int CodigoLogado
        {
            get
            {
                return Session["cod"] == null ? 0 : Convert.ToInt32(Session["cod"]);
            }
            set
            {
                Session["cod"] = value;
            }
        }
    }
}