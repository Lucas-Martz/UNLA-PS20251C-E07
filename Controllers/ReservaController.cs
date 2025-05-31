using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UNLA_PS20251C_E07.Models;

namespace UNLA_PS20251C_E07.Controllers
{
    public class ReservaController : Controller
    {
        // Usamos la lista compartida (simulada)
        private static List<Hospedaje> hospedajes = DatosSimulados.Hospedajes;

        // Simulamos reservas guardadas en memoria
        private static List<Reserva> reservas = new List<Reserva>();

        // GET: Reserva/Nueva/5
        public ActionResult Nueva(int id)
        {
            var hospedaje = hospedajes.FirstOrDefault(h => h.Id == id);
            if (hospedaje == null)
                return HttpNotFound();

            ViewBag.TituloHospedaje = hospedaje.Titulo;
            ViewBag.PrecioPorNoche = hospedaje.PrecioPorNoche;

            var reserva = new Reserva
            {
                HospedajeId = id,
                FechaInicio = DateTime.Today,
                FechaFin = DateTime.Today.AddDays(1)
            };

            return View(reserva);
        }

        // POST: Reserva/Nueva
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nueva(Reserva reserva)
        {
            var hospedaje = hospedajes.FirstOrDefault(h => h.Id == reserva.HospedajeId);
            if (hospedaje == null)
                return HttpNotFound();

            ViewBag.TituloHospedaje = hospedaje.Titulo;
            ViewBag.PrecioPorNoche = hospedaje.PrecioPorNoche;

            if (ModelState.IsValid)
            {
                // Asignar ID autoincremental
                reserva.Id = reservas.Count > 0 ? reservas.Max(r => r.Id) + 1 : 1;
                reservas.Add(reserva);

                TempData["Mensaje"] = "Reserva realizada con éxito.";
                return RedirectToAction("Confirmacion", new { id = reserva.Id });
            }

            // Si hay error en validación, volver a mostrar la vista
            return View(reserva);
        }

        // GET: Reserva/Confirmacion/1
        public ActionResult Confirmacion(int id)
        {
            var reserva = reservas.FirstOrDefault(r => r.Id == id);
            if (reserva == null)
                return HttpNotFound();

            var hospedaje = hospedajes.FirstOrDefault(h => h.Id == reserva.HospedajeId);
            ViewBag.TituloHospedaje = hospedaje?.Titulo ?? "Hospedaje";
            ViewBag.PrecioPorNoche = hospedaje?.PrecioPorNoche ?? 0;

            return View(reserva);
        }
    }
}
