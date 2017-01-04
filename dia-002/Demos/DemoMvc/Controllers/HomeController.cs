using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DemoMvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            var major = mvcName.Version.Major;
            var minor = mvcName.Version.Minor;
            var platform = isMono ? "Mono" : ".NET";

            return Content(string.Format("Running MVC: {0}.{1}, On {2}", major, minor, platform), "text/plain", Encoding.UTF8);
        }
    }
}