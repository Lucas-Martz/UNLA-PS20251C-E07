using System.Collections.Generic;

namespace UNLA_PS20251C_E07.Models
{
    public static class DatosSimulados
    {
        public static List<Servicio> ServiciosDisponibles = new List<Servicio>
        {
            new Servicio { Id = 1, Nombre = "Wi-Fi" },
            new Servicio { Id = 2, Nombre = "Piscina" },
            new Servicio { Id = 3, Nombre = "Estacionamiento" },
            new Servicio { Id = 4, Nombre = "Desayuno incluido" }
        };

        public static List<Hospedaje> Hospedajes = new List<Hospedaje>
        {
            new Hospedaje
            {
                Id = 1,
                Titulo = "Cabaña en la montaña",
                Descripcion = "Naturaleza y tranquilidad.",
                ImagenUrl = "https://imgar.zonapropcdn.com/avisos/resize/1/00/49/49/60/20/1200x1200/1802678808.jpg?isFirstImage=true",
                Ubicacion = "Patagonia",
                PrecioPorNoche = 242600m,
                CapacidadPersonas = 6,
                Servicios = new List<Servicio> { ServiciosDisponibles[0], ServiciosDisponibles[1] }
            },
            new Hospedaje
            {
                Id = 2,
                Titulo = "Casa frente al mar",
                Descripcion = "Relajate con vista al mar.",
                ImagenUrl = "https://complejoclarita.com.ar/wp-content/uploads/casas-frente-al-mar-en-la-costa-atlantica.jpg",
                Ubicacion = "Mar del Plata",
                PrecioPorNoche = 125740m,
                CapacidadPersonas = 4,
                Servicios = new List<Servicio> { ServiciosDisponibles[2], ServiciosDisponibles[3] }
            },
            new Hospedaje
            {
                Id = 3,
                Titulo = "Departamentos en la ciudad",
                Descripcion = "Cerca de todo lo que necesitás.",
                ImagenUrl = "https://imgar.zonapropcdn.com/avisos/resize/1/00/55/56/52/03/1200x1200/1959534758.jpg?isFirstImage=true",
                Ubicacion = "Capital federal",
                PrecioPorNoche = 84125m,
                CapacidadPersonas = 2,
                Servicios = new List<Servicio> { ServiciosDisponibles[0], ServiciosDisponibles[2] }
            }
        };
    }
}
