using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UNLA_PS20251C_E07.Models;

namespace UNLA_PS20251C_E07.Controllers
{
    public class HospedajeController : Controller
    {
        private static List<Hospedaje> hospedajes = new List<Hospedaje>
        {
            new Hospedaje { Id = 1, Titulo = "Cabaña en la montaña", Descripcion = "Naturaleza y tranquilidad.", ImagenUrl = "https://imgar.zonapropcdn.com/avisos/resize/1/00/49/49/60/20/1200x1200/1802678808.jpg?isFirstImage=true", Ubicacion = "Patagonia" },
            new Hospedaje { Id = 2, Titulo = "Casa frente al mar", Descripcion = "Relajate con vista al océano.", ImagenUrl = "https://complejoclarita.com.ar/wp-content/uploads/casas-frente-al-mar-en-la-costa-atlantica.jpg", Ubicacion = "Mar del Plata" },
            new Hospedaje { Id = 3, Titulo = "Depto en la ciudad", Descripcion = "Cerca de todo.", ImagenUrl = "https://imgar.zonapropcdn.com/avisos/resize/1/00/55/56/52/03/1200x1200/1959534758.jpg?isFirstImage=true", Ubicacion = "Buenos Aires" }
        };

        public ActionResult Index(string q)
        {
            var resultado = string.IsNullOrEmpty(q) ? hospedajes : hospedajes.Where(h => h.Titulo.ToLower().Contains(q.ToLower()) || h.Ubicacion.ToLower().Contains(q.ToLower())).ToList();
            return View(resultado);
        }

        public ActionResult Detalle(int id)
        {
            var hospedaje = hospedajes.FirstOrDefault(h => h.Id == id);
            if (hospedaje == null) return HttpNotFound();
            return View(hospedaje);
        }
    }
}
