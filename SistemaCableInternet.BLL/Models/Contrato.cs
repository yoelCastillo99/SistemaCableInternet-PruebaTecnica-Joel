using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaCableInternet.BLL.Models
{
    public class Contrato
    {
        public int ContratoId { get; set; }

        public int ClienteId { get; set; }

        public string? Codigo { get; set; }

        public string? Cliente { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public byte DiaPago { get; set; }

        public string Estado { get; set; } = "Activo";
    }
}

