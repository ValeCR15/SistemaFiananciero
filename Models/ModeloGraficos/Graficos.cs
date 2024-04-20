using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaFinanciero.Models.ModeloGraficos
{
    public class Graficos
    {
        public ProyeccionGasto ProyeccionGasto { get; set; }
        public ProyeccionVenta ProyeccionVenta { get; set; }

        public Graficos() { 
            ProyeccionVenta = new ProyeccionVenta();
            ProyeccionGasto = new ProyeccionGasto();
        }
    }
}