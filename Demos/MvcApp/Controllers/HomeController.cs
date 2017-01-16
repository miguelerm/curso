using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            return Content("Hola Mundo");
        }

        public ActionResult OtroIndex()
        {
            return Content("Hola Mundo 2");
        }

        public ActionResult OtroIndexMas(int id)
        {
            return Content("Hola mundo " + id);
        }
    }
}