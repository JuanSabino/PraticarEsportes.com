using PraticarEsportes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PraticarEsportes.Controllers
{
    public class HomeController : Controller
    {

        private Context db = new Context();

        public ActionResult Index()
        {
            ViewBag.Categoria = db.Categoria.ToList();
            ViewBag.Local = db.Local.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}