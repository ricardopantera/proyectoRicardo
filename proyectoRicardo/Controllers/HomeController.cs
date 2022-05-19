using proyectoRicardo.Contexto;
using proyectoRicardo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoRicardo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Productos> result = Context.GetProductos();

            return View(result);
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

        public ActionResult ejemplo()
        {
            return View();
        }
        
    }
}