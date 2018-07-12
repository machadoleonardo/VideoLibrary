using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoLibrary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Descrição da aplicação:";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contatos da página.";

            return View();
        }
    }
}