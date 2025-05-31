using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UNLA_PS20251C_E07.Models;
using static System.Net.WebRequestMethods;

namespace UNLA_PS20251C_E07.Controllers
{
    public class HospedajeController : Controller
    {
        private static List<Servicio> serviciosDisponibles = new List<Servicio>
        {
            new Servicio { Id = 1, Nombre = "Wi-Fi" },
            new Servicio { Id = 2, Nombre = "Piscina" },
            new Servicio { Id = 3, Nombre = "Estacionamiento" },
            new Servicio { Id = 4, Nombre = "Desayuno incluido" }
        };

        private static List<Hospedaje> hospedajes = new List<Hospedaje>
        {
            new Hospedaje
            {
                Id = 1,
                Titulo = "Cabaña en la montaña",
                Descripcion = "Naturaleza y tranquilidad.",
                ImagenUrl = "https://imgar.zonapropcdn.com/avisos/resize/1/00/49/49/60/20/1200x1200/1802678808.jpg?isFirstImage=true",
                Ubicacion = "Patagonia",
                PrecioPorNoche = 242.600m,
                CapacidadPersonas = 6,
                Servicios = new List<Servicio> { serviciosDisponibles[0], serviciosDisponibles[1] }
            },
            new Hospedaje
            {
                Id = 2,
                Titulo = "Casa frente al mar",
                Descripcion = "Relajate con vista al mar.",
                ImagenUrl = "https://complejoclarita.com.ar/wp-content/uploads/casas-frente-al-mar-en-la-costa-atlantica.jpg",
                Ubicacion = "Mar del Plata",
                PrecioPorNoche = 125.740m,
                CapacidadPersonas = 4,
                Servicios = new List<Servicio> { serviciosDisponibles[2], serviciosDisponibles[3] }
            },
            new Hospedaje
            {
                Id = 3,
                Titulo = "Departamentos en la ciudad",
                Descripcion = "Cerca de todo lo que necesitás.",
                ImagenUrl = "https://imgar.zonapropcdn.com/avisos/resize/1/00/55/56/52/03/1200x1200/1959534758.jpg?isFirstImage=true",
                Ubicacion = "Capital federal",
                PrecioPorNoche = 84.125m,
                CapacidadPersonas = 2,
                Servicios = new List<Servicio> { serviciosDisponibles[0], serviciosDisponibles[2] }
            }

        };

        public ActionResult Index(string q)
        {
            var resultado = string.IsNullOrEmpty(q)
                ? hospedajes
                : hospedajes.Where(h => h.Titulo.ToLower().Contains(q.ToLower()) || h.Ubicacion.ToLower().Contains(q.ToLower())).ToList();
            return View(resultado);
        }

        public ActionResult Detalle(int id)
        {
            var hospedaje = hospedajes.FirstOrDefault(h => h.Id == id);
            if (hospedaje == null) return HttpNotFound();
            return View(hospedaje);
        }

        // GET: Hospedaje/Nuevo
        public ActionResult Nuevo()
        {
            ViewBag.Servicios = serviciosDisponibles;
            return View();
        }

        // POST: Hospedaje/Nuevo
        [HttpPost]
        public ActionResult Nuevo(Hospedaje hospedaje, int[] serviciosSeleccionados)
        {
            hospedaje.Id = hospedajes.Max(h => h.Id) + 1;
            hospedaje.Servicios = serviciosDisponibles.Where(s => serviciosSeleccionados.Contains(s.Id)).ToList();
            hospedajes.Add(hospedaje);
            return RedirectToAction("Index");
        }

    }
}
