using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UNLA_PS20251C_E07.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required]
        public int HospedajeId { get; set; }

        [Required]
        public string NombreCliente { get; set; }

        [Required, EmailAddress]
        public string EmailCliente { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }

        public Hospedaje Hospedaje { get; set; }
    }
}