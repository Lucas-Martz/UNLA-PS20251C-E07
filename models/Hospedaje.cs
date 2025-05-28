using System.Collections.Generic;

namespace UNLA_PS20251C_E07.Models
{
    public class Hospedaje
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public string ImagenUrl { get; set; }
        public decimal PrecioPorNoche { get; set; }         
        public int CapacidadPersonas { get; set; }
        public List<Servicio> Servicios { get; set; } = new List<Servicio>();

    }
}
