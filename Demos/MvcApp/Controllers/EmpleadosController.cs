using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using System.ComponentModel.DataAnnotations;
using MvcApp.Properties;
using MvcApp.Validators;

namespace MvcApp.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        public ActionResult Index()
        {

            EmpleadoViewModel[] model;

            using (var db = new SQLiteConnection(@"Data Source=c:\db\app.db;Version=3;"))
            {
                db.Open();

                model = db.Query<EmpleadoViewModel>("SELECT * FROM Empleados").ToArray();
            }

            return View(model);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(CrearEmpleadoViewModel model)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Error");
                return View(model);
            }

            using (var db = new SQLiteConnection(@"Data Source=c:\db\app.db;Version=3;"))
            {
                db.Open();
                db.Execute("INSERT INTO Empleados (Nombre) VALUES (@Nombre)", model);
            }

            return RedirectToAction("Index");
        }

        public class CrearEmpleadoViewModel
        {
            [Required(ErrorMessage = "Requerido")]
            [StringLength(100, MinimumLength = 2, ErrorMessage = "Longitud ({0}) [{1} - {2}]")]
            public string Nombre { get; set; }

            [Nit]
            public string Nit { get; set; }
        }

        public class EmpleadoViewModel
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }
    }
}