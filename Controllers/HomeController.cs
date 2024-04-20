using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaFinanciero.Models;
using SistemaFinanciero.Models.ModeloGraficos;


namespace SistemaFinanciero.Controllers
{
    public class HomeController : Controller
    {
        private SFEntities db = new SFEntities();

        // GET: ProyeccionVentas
        public ActionResult Index()
        {
            List<Graficos> graficosList = new List<Graficos>();

            // Obtener todas las proyecciones de venta
            List<ProyeccionVenta> proyeccionesVenta = db.ProyeccionVentas.Include(p => p.CuentaContable).ToList();

            // Obtener todas las proyecciones de gasto
            List<ProyeccionGasto> proyeccionesGasto = db.ProyeccionGastos.Include(p => p.CuentaContable).ToList();

            // Agregar las proyecciones a la lista de gráficos
            foreach (var proyeccionVenta in proyeccionesVenta)
            {
                Graficos graficos = new Graficos();
                graficos.ProyeccionVenta = proyeccionVenta;
                graficosList.Add(graficos);
            }

            foreach (var proyeccionGasto in proyeccionesGasto)
            {
                Graficos graficos = new Graficos();
                graficos.ProyeccionGasto = proyeccionGasto;
                graficosList.Add(graficos);
            }

            return View(graficosList);
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